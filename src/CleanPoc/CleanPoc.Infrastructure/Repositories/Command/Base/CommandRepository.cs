using CleanPoc.Core.Repositories.Command.Base;
using CleanPoc.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanPoc.Infrastructure.Repositories.Command.Base;

public class CommandRepository<T> : ICommandRepository<T> where T : class
{
    
    private readonly IDbContextFactory<CleanContext> _dbContextFactory;

    protected CommandRepository(IDbContextFactory<CleanContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    
    

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await using var db = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        await db.Set<T>().AddAsync(entity, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
        return entity;
        
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        await using var db = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        db.Entry(entity).State = EntityState.Modified;
        await db.SaveChangesAsync(cancellationToken);
    }
    
    public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        await using var db = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        db.Set<T>().Remove(entity);
        await db.SaveChangesAsync(cancellationToken);
    }
    
}