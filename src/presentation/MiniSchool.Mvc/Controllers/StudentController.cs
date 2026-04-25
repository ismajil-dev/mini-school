using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniSchool.Application.Dtos.Requests.Students;
using MiniSchool.Application.Repositories.Queries;

namespace MiniSchool.Mvc.Controllers;

public class StudentController : Controller
{
    private readonly IStudentQueryRepository _queryRepository;
    private readonly IMediator _mediator;

    public StudentController(IStudentQueryRepository queryRepository, IMediator mediator)
    {
        _queryRepository = queryRepository;
        _mediator = mediator;
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var list = await _queryRepository.FindAllToListAsync(false, ct);
        return View(list);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View(new StudentRegisterRequest { Name = "", Surname = "", ClassLevel = 1 });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(StudentRegisterRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid) return View(request);

        await _mediator.Send(request, ct);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Modify(int id, CancellationToken ct)
    {
        var entity = await _queryRepository.FindByIdAsync(id, false, ct);
        if (entity == null) return NotFound();

        var requestModel = new StudentModifyRequest
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            ClassLevel = entity.ClassLevel
        };

        return View(requestModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Modify(StudentModifyRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid) return View(request);

        await _mediator.Send(request, ct);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Archive([FromBody] StudentArchiveRequest request, CancellationToken ct)
    {
        if (request == null || !request.Ids.Any()) return BadRequest("Data tapılmadı");

        var archivedItems = await _mediator.Send(request, ct);
        var ids = string.Join(", ", archivedItems.Select(x => x.Id));

        return Json(new { success = true, message = $"Uğurla arxivlənən Şagird ID-ləri: {ids}" });
    }
}
