using MiniSchool.Shared.Abstracts.Entities;

namespace MiniSchool.Application.Dtos.Entities;

public sealed class LessonDto
    : BaseEntity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public byte ClassLevel { get; set; }
    public string TeacherName { get; set; } = null!;
    public string TeacherSurname { get; set; } = null!;
}
