using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MiniSchool.Shared.Interfaces.Repositories;

namespace MiniSchool.Infrastructure.Repositories.Generals;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private IDbContextTransaction? _currentTransaction;

    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await _context.SaveChangesAsync(ct);
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken ct = default)
    {
        if (_currentTransaction != null)
            return _currentTransaction;

        _currentTransaction = await _context.Database.BeginTransactionAsync(ct);
        return _currentTransaction;
    }

    public async Task CommitTransactionAsync(CancellationToken ct = default)
    {
        try
        {
            // Transaction-u commit etməzdən əvvəl dəyişiklikləri yadda saxlayırıq
            await SaveChangesAsync(ct);

            if (_currentTransaction != null)
            {
                await _currentTransaction.CommitAsync(ct);
            }
        }
        catch
        {
            // Xəta baş verərsə daxili olaraq Rollback edirik
            await RollbackTransactionAsync(ct);
            throw; // 'ex' yazmırıq ki, Stack Trace qorunsun
        }
        finally
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken ct = default)
    {
        if (_currentTransaction != null)
        {
            await _currentTransaction.RollbackAsync(ct);
            await _currentTransaction.DisposeAsync();
            _currentTransaction = null;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
        GC.SuppressFinalize(this);
    }
}
