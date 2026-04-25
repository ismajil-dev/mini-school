using MiniSchool.Domain.Entities;
using MiniSchool.Shared.Interfaces.Repositories;

namespace MiniSchool.Application.Repositories.Queries;

public interface ILessonQueryRepository
    : IGenericQueryRepository<Lesson>
{
}
