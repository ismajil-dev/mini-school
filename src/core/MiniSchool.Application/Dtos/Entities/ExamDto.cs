using MiniSchool.Shared.Abstracts.Entities;

namespace MiniSchool.Application.Dtos.Entities;

public sealed class ExamDto
    : BaseEntity
{
    public DateTime ExamDate { get; set; }
    public byte Grade { get; set; }

    public int LessonId { get; set; }
    public int StudentId { get; set; }
}
