using System.Linq.Expressions;

namespace CleanPoc.Application.Response.Leads;

public abstract class LeadResponse
{
    public class List
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        
        public static Expression<Func<Core.Entities.Lead, List>> Selector =>
        record => new List
        {   
            Id = record.Id,
            Name = $"{record.FirstName} {record.LastName}",
            Email = record.Email,
            ContactNumber = record.ContactNumber,
            Address = record.Address

        };
    }
    
    public class Detail
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        
        public static Expression<Func<Core.Entities.Lead, Detail>> Selector =>
        record => new Detail
        {   
            Id = record.Id,
            FirstName = record.FirstName,
            LastName = record.LastName,
            Email = record.Email,
            ContactNumber = record.ContactNumber,
            Address = record.Address

        };
    }
    
}