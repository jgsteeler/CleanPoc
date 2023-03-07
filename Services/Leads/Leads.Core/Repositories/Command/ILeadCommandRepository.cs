using Leads.Core.Entities;
using Leads.Core.Repositories.Command.Base;

namespace Leads.Core.Repositories.Command;

public interface ILeadCommandRepository : ICommandRepository<Entities.Leads>
{
    
}