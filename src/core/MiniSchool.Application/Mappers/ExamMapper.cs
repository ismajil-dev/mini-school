using Riok.Mapperly.Abstractions;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Application.Dtos.Requests.Exams;
using MiniSchool.Domain.Entities;

namespace MiniSchool.Application.Mappers;

[Mapper]
public static partial class ExamMapper
{
    public static partial Exam ToEntity(ExamRegisterRequest request);
    public static partial void UpdateEntity(ExamModifyRequest request, Exam entity);
    public static partial ExamDto ToDto(Exam entity);
}
