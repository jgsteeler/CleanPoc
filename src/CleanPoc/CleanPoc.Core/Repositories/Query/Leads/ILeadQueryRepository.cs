using CleanPoc.Core.Repositories.Query.Base;

namespace CleanPoc.Core.Repositories.Query.Leads;

public interface ILeadQueryRepository : IQueryRepository<Entities.Lead>
{
    
    Task<Entities.Lead> GetLeadById(int id, CancellationToken cancellationToken);
    Task<Entities.Lead> GetLeadByEmail(string email, CancellationToken cancellationToken);
}

