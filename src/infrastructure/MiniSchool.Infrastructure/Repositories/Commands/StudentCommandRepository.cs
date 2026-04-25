using Microsoft.EntityFrameworkCore;
using MiniSchool.Application.Repositories.Commands;
using MiniSchool.Domain.Entities;
using MiniSchool.Shared.Abstracts.Repositories;

namespace MiniSchool.Infrastructure.Repositories.Commands;

internal sealed class StudentCommandRepository
    : GenericActiveCommandRepository<Student>
    , IStudentCommandRepository
{
    public StudentCommandRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
