using System.Diagnostics.CodeAnalysis;
using CleanPoc.Core.Entities;
using CleanPoc.Core.Repositories.Query.Leads;
using CleanPoc.Infrastructure.Data;
using CleanPoc.Infrastructure.Repositories.Query.Base;
using Microsoft.EntityFrameworkCore;

namespace CleanPoc.Infrastructure.Repositories.Query.Leads;

[SuppressMessage("ReSharper", "HeapView.BoxingAllocation")]
public class LeadsQueryRepository : QueryRepository<Lead>, ILeadQueryRepository
{
    private readonly IDbContextFactory<CleanContext> _contextFactory;



    public LeadsQueryRepository(IDbContextFactory<CleanContext> contextFactory) : base(contextFactory)
    {
       
    }

   

    public async Task<Lead> GetLeadById(int id, CancellationToken cancellationToken)
    {
        await using var db = await ContextFactory.CreateDbContextAsync(cancellationToken);
        return await db.Set<Lead>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        
    }

    public async Task<Lead> GetLeadByEmail(string email, CancellationToken cancellationToken)
    {
        await using var db = await ContextFactory.CreateDbContextAsync(cancellationToken);
        return await db.Set<Lead>().AsNoTracking().FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
       
    }
}