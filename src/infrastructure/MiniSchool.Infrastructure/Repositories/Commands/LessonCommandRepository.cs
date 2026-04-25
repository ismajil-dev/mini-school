using Microsoft.EntityFrameworkCore;
using MiniSchool.Application.Repositories.Commands;
using MiniSchool.Domain.Entities;
using MiniSchool.Shared.Abstracts.Repositories;
using MiniSchool.Shared.Interfaces.Repositories;

namespace MiniSchool.Infrastructure.Repositories.Commands;

internal sealed class LessonCommandRepository
    : GenericActiveCommandRepository<Lesson>
    , ILessonCommandRepository
{
    public LessonCommandRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
