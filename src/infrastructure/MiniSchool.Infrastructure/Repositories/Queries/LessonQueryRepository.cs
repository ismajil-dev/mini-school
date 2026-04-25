using Microsoft.EntityFrameworkCore;
using MiniSchool.Application.Repositories.Queries;
using MiniSchool.Domain.Entities;
using MiniSchool.Shared.Abstracts.Repositories;

namespace MiniSchool.Infrastructure.Repositories.Queries;

internal sealed class LessonQueryRepository
    : GenericQueryRepository<Lesson>
    , ILessonQueryRepository
{
    public LessonQueryRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
