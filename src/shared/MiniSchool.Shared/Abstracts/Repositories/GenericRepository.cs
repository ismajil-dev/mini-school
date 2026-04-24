using Microsoft.EntityFrameworkCore;
using MiniSchool.Shared.Interfaces.Entities;
using MiniSchool.Shared.Interfaces.Repositories;

namespace MiniSchool.Shared.Abstracts.Repositories;

public abstract class GenericRepository<T>
    : IGenericRepository<T>
    where T : class, IEntity, new()
{
    public readonly DbContext _context;
    public DbSet<T> _table;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }
}