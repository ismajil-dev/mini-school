using MiniSchool.Shared.Interfaces.Entities;
using System.Linq.Expressions;

namespace MiniSchool.Shared.Interfaces.Repositories;

public interface IGenericActiveCommandRepository<T>
    : IGenericRepository<T>
    where T : IActiveEntity, new()
{
    Task RegisterAsync(T entity, CancellationToken ct = default);
    Task RegisterRangeAsync(IEnumerable<T> entities, CancellationToken ct = default);

    Task ModifyAsync(T entity, CancellationToken ct = default);
    Task ModifyRangeAsync(IEnumerable<T> entities, CancellationToken ct = default);

    Task RemoveAsync(T entity, CancellationToken ct = default);
    Task RemoveRangeAsync(IEnumerable<T> entities, CancellationToken ct = default);

    Task RemoveByExpressionAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);

    //  Soft delete (Is archived)
}

