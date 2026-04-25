using Microsoft.EntityFrameworkCore;
using MiniSchool.Application.Repositories.Queries;
using MiniSchool.Domain.Entities;
using MiniSchool.Shared.Abstracts.Repositories;

namespace MiniSchool.Infrastructure.Repositories.Queries;

internal sealed class StudentQueryRepository
    : GenericQueryRepository<Student>
    , IStudentQueryRepository
{
    public StudentQueryRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
