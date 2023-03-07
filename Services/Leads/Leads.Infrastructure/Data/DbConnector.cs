using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace Leads.Infrastructure.Data;

public class DbConnector
{
    private readonly IConfiguration _configuration;
    
    public DbConnector(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        
        return new SqliteConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}