using MiniSchool.Shared.Abstracts.Entities;

namespace MiniSchool.Domain.Entities;

public class Student : BaseActiveEntity
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public byte ClassLevel { get; set; }

    public ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
