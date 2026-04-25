using Microsoft.EntityFrameworkCore;
using MiniSchool.Application.Repositories.Commands;
using MiniSchool.Domain.Entities;
using MiniSchool.Shared.Abstracts.Repositories;

namespace MiniSchool.Infrastructure.Repositories.Commands;

internal sealed class ExamCommandRepository
    : GenericActiveCommandRepository<Exam>
    , IExamCommandRepository
{
    public ExamCommandRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
