using Microsoft.EntityFrameworkCore;
using MiniSchool.Shared.Interfaces.Entities;
using MiniSchool.Shared.Interfaces.Repositories;
using System.Linq.Expressions;

namespace MiniSchool.Shared.Abstracts.Repositories;

public abstract class GenericActiveCommandRepository<T>
    : GenericRepository<T>
    , IGenericActiveCommandRepository<T>
    where T : class, IActiveEntity, new()
{
    public GenericActiveCommandRepository(DbContext dbContext) : base(dbContext) { }

    // --- Register (Insert) ---

    public async Task RegisterAsync(T entity, CancellationToken ct = default)
    {
        await _table.AddAsync(entity, ct);
        // UnitOfWork yoxdursa, aşağıdakı sətri aktiv edin:
        // await _context.SaveChangesAsync(ct); 
    }

    public async Task RegisterRangeAsync(IEnumerable<T> entities, CancellationToken ct = default)
    {
        // Batch Insert: EF Core bunu avtomatik optimallaşdırır
        await _table.AddRangeAsync(entities, ct);
    }

    // --- Modify (Update) ---

    public async Task ModifyAsync(T entity, CancellationToken ct = default)
    {
        _table.Update(entity);
        await Task.CompletedTask;
    }

    public async Task ModifyRangeAsync(IEnumerable<T> entities, CancellationToken ct = default)
    {
        _table.UpdateRange(entities);
        await Task.CompletedTask;
    }

    // --- Remove (Delete) ---

    public async Task RemoveAsync(T entity, CancellationToken ct = default)
    {
        _table.Remove(entity);
        await Task.CompletedTask;
    }

    public async Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken ct = default)
    {
        _table.RemoveRange(entities);
        await Task.CompletedTask;
    }

    public async Task RemoveByExpressionAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default)
    {
        // PERFORMANCE FIX: EF Core 7+ (ExecuteDelete)
        // Datanı RAM-a gətirmir (ToListAsync yoxdur), birbaşa SQL-də DELETE göndərir.
        await _table.Where(predicate).ExecuteDeleteAsync(ct);
    }

    //   Soft delete metodlarıdı əlavə et
}

