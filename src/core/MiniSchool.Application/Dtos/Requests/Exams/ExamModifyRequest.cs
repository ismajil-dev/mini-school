using MediatR;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Shared.Abstracts.Requests;

namespace MiniSchool.Application.Dtos.Requests.Exams;

public sealed class ExamModifyRequest
    : BaseModifyRequest
    , IRequest<ExamDto>
{

    public required DateTime ExamDate { get; set; }
    public required byte Grade { get; set; }
    public required int LessonId { get; set; }
    public required int StudentId { get; set; }

}
