using CleanPoc.Core.Repositories.Query.Base;
using CleanPoc.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanPoc.Infrastructure.Repositories.Query.Base;

public abstract class QueryRepository<T> : IQueryRepository<T> where T : class
{
    protected QueryRepository(IDbContextFactory<CleanContext> contextFactory)
    {
        ContextFactory = contextFactory;
    }

    protected IDbContextFactory<CleanContext> ContextFactory { get; }


    public async Task<IQueryable<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        await using var db = await ContextFactory.CreateDbContextAsync(cancellationToken);
       
            var result = await db.Set<T>().AsNoTracking().ToListAsync(cancellationToken); 
            
            return result.AsQueryable();
    }
}