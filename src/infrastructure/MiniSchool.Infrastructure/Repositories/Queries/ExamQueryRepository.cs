using Microsoft.EntityFrameworkCore;
using MiniSchool.Application.Repositories.Queries;
using MiniSchool.Domain.Entities;
using MiniSchool.Shared.Abstracts.Repositories;

namespace MiniSchool.Infrastructure.Repositories.Queries;

internal sealed class ExamQueryRepository
    : GenericQueryRepository<Exam>
    , IExamQueryRepository
{
    public ExamQueryRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
