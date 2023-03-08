using Microsoft.EntityFrameworkCore;

namespace CleanPoc.Infrastructure.Data;



public class CleanContext : DbContext
{
    public CleanContext(DbContextOptions<CleanContext> options) : base(options)
    {
        
    }
    
    public DbSet<CleanPoc.Core.Entities.Lead> Leads { get; set; }
    
}