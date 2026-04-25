using Riok.Mapperly.Abstractions;
using MiniSchool.Application.Dtos.Entities;
using MiniSchool.Application.Dtos.Requests.Lessons;
using MiniSchool.Domain.Entities;

namespace MiniSchool.Application.Mappers;

[Mapper]
public static partial class LessonMapper
{
    public static partial Lesson ToEntity(LessonRegisterRequest request);
    public static partial void UpdateEntity(LessonModifyRequest request, Lesson entity);
    public static partial LessonDto ToDto(Lesson entity);
}
