using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniSchool.Application.Dtos.Requests.Lessons;
using MiniSchool.Application.Repositories.Queries;
using MiniSchool.Infrastructure.Repositories.Queries;

namespace MiniSchool.Mvc.Controllers;

public class LessonController : Controller
{
    private readonly ILessonQueryRepository _queryRepository;
    private readonly IMediator _mediator;

    public LessonController(ILessonQueryRepository queryRepository, IMediator mediator)
    {
        _queryRepository = queryRepository;
        _mediator = mediator;
    }

    // 1. Siyahı Alqoritmi (List Component)
    public async Task<IActionResult> Index(CancellationToken ct)
    {
        // Yalnız arxivlənməmişləri gətiririk
        var list = await _queryRepository.FindAllToListAsync(false, ct);
        return View(list);
    }

    // 2. Qeydiyyat Alqoritmi (Register Component)
    [HttpGet]
    public IActionResult Register()
    {
        return View(new LessonRegisterRequest { Code = "", Name = "", ClassLevel = 1, TeacherName = "", TeacherSurname = "" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(LessonRegisterRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid) return View(request);

        await _mediator.Send(request, ct);
        return RedirectToAction(nameof(Index));
    }

    // 3. Dəyişmə Alqoritmi (Modify Component)
    [HttpGet]
    public async Task<IActionResult> Modify(int id, CancellationToken ct)
    {
        var entity = await _queryRepository.FindByIdAsync(id, false, ct);
        if (entity == null) return NotFound();

        var requestModel = new LessonModifyRequest
        {
            Id = entity.Id,
            Code = entity.Code,
            Name = entity.Name,
            ClassLevel = entity.ClassLevel,
            TeacherName = entity.TeacherName,
            TeacherSurname = entity.TeacherSurname
        };

        return View(requestModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Modify(LessonModifyRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid) return View(request);

        await _mediator.Send(request, ct);
        return RedirectToAction(nameof(Index));
    }

    // 4. Archive Handler'ə yönləndirmə (AJAX Call üçün)
    [HttpPost]
    public async Task<IActionResult> Archive([FromBody] LessonArchiveRequest request, CancellationToken ct)
    {
        if (request == null || !request.Ids.Any()) return BadRequest("Data tapılmadı");

        var archivedItems = await _mediator.Send(request, ct);
        var ids = string.Join(", ", archivedItems.Select(x => x.Id));

        return Json(new { success = true, message = $"Uğurla arxivlənən ID-lər: {ids}" });
    }
}