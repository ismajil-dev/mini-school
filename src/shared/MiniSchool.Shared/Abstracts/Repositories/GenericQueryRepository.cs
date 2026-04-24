using Microsoft.EntityFrameworkCore;
using MiniSchool.Shared.Interfaces.Entities;
using MiniSchool.Shared.Interfaces.Repositories;
using System.Linq;
using System.Linq.Expressions;

namespace MiniSchool.Shared.Abstracts.Repositories;

public abstract class GenericQueryRepository<T>
    : GenericRepository<T>
    , IGenericQueryRepository<T>
    // Constraint: Keyset pagination üçün T-nin IHasKeyset olduğu bilinməlidir
    where T : class, IEntity, new()
{
    public GenericQueryRepository(DbContext dbContext) : base(dbContext) { }



    protected virtual IQueryable<T> PrepareQuery(
    bool isTracking)
    {
        IQueryable<T> query = _table;

        if (!isTracking)
        {
            query = query.AsNoTracking();
        }

        return query;
    }





    
    public IQueryable<T> QueryAll(bool isTracking = false)
        => PrepareQuery(isTracking);

    public IQueryable<T> QueryWhere(Expression<Func<T, bool>> predicate, bool isTracking = false)
        => PrepareQuery(isTracking).Where(predicate);

    public IAsyncEnumerable<T> FindAllAsync(bool isTracking = false, CancellationToken ct = default)
        => PrepareQuery(isTracking).AsAsyncEnumerable();

    public Task<List<T>> FindAllToListAsync(bool isTracking = false, CancellationToken ct = default)
        => PrepareQuery(isTracking).ToListAsync(ct);


    public Task<T?> FindByIdAsync(int id, bool isTracking = false, CancellationToken ct = default)
        
        => PrepareQuery(isTracking).FirstOrDefaultAsync(e => e.Id.Equals(id), ct);

    public Task<bool> ExistAsync(Expression<Func<T, bool>> filter, bool isTracking = false, CancellationToken ct = default)
        => PrepareQuery(isTracking).AnyAsync(filter, ct);

}
