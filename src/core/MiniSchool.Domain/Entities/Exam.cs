using MiniSchool.Shared.Abstracts.Entities;

namespace MiniSchool.Domain.Entities;

public class Exam : BaseActiveEntity
{
    public DateTime ExamDate { get; set; }
    public byte Grade { get; set; }

    public int LessonId { get; set; }
    public int StudentId { get; set; }

    public Lesson Lesson { get; set; } = null!;
    public Student Student { get; set; } = null!;
}