using MediatR;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Shared.Abstracts.Requests;

namespace MiniSchool.Application.Dtos.Requests.Lessons;

public sealed class LessonModifyRequest
    : BaseModifyRequest
    , IRequest<LessonDto>
{

    public required string Code { get; set; } = null!;
    public required string Name { get; set; } = null!;
    public required byte ClassLevel { get; set; }
    public required string TeacherName { get; set; } = null!;
    public required string TeacherSurname { get; set; } = null!;

}
