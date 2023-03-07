using Leads.Core.Entities;
using Leads.Core.Repositories.Query.Base;

namespace Leads.Core.Repositories.Query;

public interface ILeadQueryRepository : IQueryRepository<Entities.Leads>
{
    Task<Entities.Leads> GetLeadByIdAsync(int id);
    Task<Entities.Leads> GetLeadByEmailAsync(string email);
    
    
}