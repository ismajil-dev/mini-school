using Riok.Mapperly.Abstractions;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Application.Dtos.Requests.Students;
using MiniSchool.Domain.Entities;

namespace MiniSchool.Application.Mappers;

[Mapper]
public static partial class StudentMapper
{
    public static partial Student ToEntity(StudentRegisterRequest request);
    public static partial void UpdateEntity(StudentModifyRequest request, Student entity);
    public static partial StudentDto ToDto(Student entity);
}
