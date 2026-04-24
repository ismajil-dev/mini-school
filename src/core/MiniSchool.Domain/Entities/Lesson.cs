using MiniSchool.Shared.Abstracts.Entities;

namespace MiniSchool.Domain.Entities;

public class Lesson : BaseActiveEntity
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public byte ClassLevel { get; set; }
    public string TeacherName { get; set; } = null!;
    public string TeacherSurname { get; set; } = null!;

    public ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
