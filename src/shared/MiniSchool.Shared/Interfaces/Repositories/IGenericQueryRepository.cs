using MiniSchool.Shared.Interfaces.Entities;
using System.Linq.Expressions;

namespace MiniSchool.Shared.Interfaces.Repositories;

public interface IGenericQueryRepository<T>
    : IGenericRepository<T>
    where T : IEntity, new()
{
    public IQueryable<T> QueryAll(bool isTracking = false);
    IQueryable<T> QueryWhere(Expression<Func<T, bool>> predicate, bool isTracking = false);
    public IAsyncEnumerable<T> FindAllAsync(bool isTracking = false, CancellationToken ct = default);
    public Task<List<T>> FindAllToListAsync(bool isTracking = false, CancellationToken ct = default);
    public Task<T?> FindByIdAsync(int id, bool isTracking = false, CancellationToken ct = default);
    public Task<bool> ExistAsync(Expression<Func<T, bool>> filter, bool isTracking = false, CancellationToken ct = default);
}

