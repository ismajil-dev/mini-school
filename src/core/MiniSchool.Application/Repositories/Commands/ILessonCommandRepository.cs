using MiniSchool.Domain.Entities;
using MiniSchool.Shared.Interfaces.Repositories;

namespace MiniSchool.Application.Repositories.Commands;

public interface ILessonCommandRepository
    : IGenericActiveCommandRepository<Lesson>
{
}
