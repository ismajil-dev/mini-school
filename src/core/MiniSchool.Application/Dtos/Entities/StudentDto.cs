using MiniSchool.Shared.Abstracts.Entities;

namespace MiniSchool.Application.Dtos.Entities;

public sealed class StudentDto
    : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public byte ClassLevel { get; set; }
}
