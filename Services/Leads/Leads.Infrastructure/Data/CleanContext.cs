using Microsoft.EntityFrameworkCore;

namespace Leads.Infrastructure.Data;



public class CleanContext : DbContext
{
    public CleanContext(DbContextOptions<CleanContext> options) : base(options)
    {
        
    }
    
    public DbSet<Core.Entities.Leads> Leads { get; set; }
    
}