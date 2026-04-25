using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniSchool.Application.Dtos.Requests.Exams;
using MiniSchool.Application.Repositories.Queries;

namespace MiniSchool.Mvc.Controllers;

public class ExamController : Controller
{
    private readonly IExamQueryRepository _queryRepository;
    private readonly ILessonQueryRepository _lessonQueryRepository;
    private readonly IStudentQueryRepository _studentQueryRepository;
    private readonly IMediator _mediator;

    public ExamController(
        IExamQueryRepository queryRepository,
        ILessonQueryRepository lessonQueryRepository,
        IStudentQueryRepository studentQueryRepository,
        IMediator mediator)
    {
        _queryRepository = queryRepository;
        _lessonQueryRepository = lessonQueryRepository;
        _studentQueryRepository = studentQueryRepository;
        _mediator = mediator;
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        // View-da Lesson və Student adlarını göstərə bilmək üçün EF Core tərəfindən 
        // include edilməyibsə ID-lər ilə idarə edəcəyik, lakin ideal ssenaridə 
        // FindAllToListAsync daxilində Include məntiqi olmalıdır.
        var list = await _queryRepository.FindAllToListAsync(false, ct);
        return View(list);
    }

    private async Task LoadDropdownsAsync(CancellationToken ct)
    {
        var lessons = await _lessonQueryRepository.FindAllToListAsync(false, ct);
        var students = await _studentQueryRepository.FindAllToListAsync(false, ct);

        ViewBag.Lessons = new SelectList(lessons, "Id", "Name");
        ViewBag.Students = new SelectList(students.Select(s => new {
            s.Id,
            FullName = $"{s.Name} {s.Surname} (Sinif: {s.ClassLevel})"
        }), "Id", "FullName");
    }

    [HttpGet]
    public async Task<IActionResult> Register(CancellationToken ct)
    {
        await LoadDropdownsAsync(ct);
        return View(new ExamRegisterRequest { ExamDate = DateTime.Now, Grade = 0, LessonId = 0, StudentId = 0 });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(ExamRegisterRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            await LoadDropdownsAsync(ct);
            return View(request);
        }

        await _mediator.Send(request, ct);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Modify(int id, CancellationToken ct)
    {
        var entity = await _queryRepository.FindByIdAsync(id, false, ct);
        if (entity == null) return NotFound();

        await LoadDropdownsAsync(ct);

        var requestModel = new ExamModifyRequest
        {
            Id = entity.Id,
            ExamDate = entity.ExamDate,
            Grade = entity.Grade,
            LessonId = entity.LessonId,
            StudentId = entity.StudentId
        };

        return View(requestModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Modify(ExamModifyRequest request, CancellationToken ct)
    {
        if (!ModelState.IsValid)
        {
            await LoadDropdownsAsync(ct);
            return View(request);
        }

        await _mediator.Send(request, ct);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Archive([FromBody] ExamArchiveRequest request, CancellationToken ct)
    {
        if (request == null || !request.Ids.Any()) return BadRequest("Data tapılmadı");

        var archivedItems = await _mediator.Send(request, ct);
        var ids = string.Join(", ", archivedItems.Select(x => x.Id));

        return Json(new { success = true, message = $"Uğurla arxivlənən İmtahan ID-ləri: {ids}" });
    }
}
