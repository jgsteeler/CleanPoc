using System.ComponentModel.DataAnnotations.Schema;
using CleanPoc.Core.Entities.Base;

namespace CleanPoc.Core.Entities;

[Table("Leads")]
public class Lead : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string ContactNumber { get; set; }
    public string Address { get; set; }
    
}