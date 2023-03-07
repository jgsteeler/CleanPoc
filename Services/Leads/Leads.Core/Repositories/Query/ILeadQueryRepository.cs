using Leads.Core.Entities;
using Leads.Core.Repositories.Query.Base;

namespace Leads.Core.Repositories.Query;

public interface ILeadQueryRepository : IQueryRepository<Lead>
{
    Task<Lead> GetLeadByIdAsync(int id);
    Task<Lead> GetLeadByEmailAsync(string email);
    
    
}