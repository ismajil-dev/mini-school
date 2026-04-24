using Microsoft.EntityFrameworkCore.Storage;

namespace MiniSchool.Shared.Interfaces.Repositories;

public interface IUnitOfWork : IAsyncDisposable, IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken ct = default);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken ct = default);
    Task CommitTransactionAsync(CancellationToken ct = default);
    Task RollbackTransactionAsync(CancellationToken ct = default);

}
