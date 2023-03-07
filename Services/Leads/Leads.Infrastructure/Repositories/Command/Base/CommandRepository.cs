using Leads.Core.Repositories.Command.Base;
using Leads.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Leads.Infrastructure.Repositories.Command.Base;

public class CommandRepository<T> : ICommandRepository<T> where T : class
{
    
    private readonly IDbContextFactory<CleanContext> _context;

    public CommandRepository(IDbContextFactory<CleanContext> context)
    {
        _context = context;
    }
    
    

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await using var context = await _context.CreateDbContextAsync(cancellationToken); 
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}