using CleanPoc.Core.Repositories.Command.Leads;
using CleanPoc.Infrastructure.Data;
using CleanPoc.Infrastructure.Repositories.Command.Base;
using Microsoft.EntityFrameworkCore;

namespace CleanPoc.Infrastructure.Repositories.Command.Leads;

public class LeadCommandRepository : CommandRepository<CleanPoc.Core.Entities.Lead>, ILeadCommandRepository
{
    
    
    public LeadCommandRepository(IDbContextFactory<CleanContext> dbContextFactory) : base(dbContextFactory)
    {
    
    }
    
}