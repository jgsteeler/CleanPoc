using Leads.Core.Entities.Base;

namespace Leads.Core.Entities;

public class Lead : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string ContactNumber { get; set; }
    public string Address { get; set; }
    
}