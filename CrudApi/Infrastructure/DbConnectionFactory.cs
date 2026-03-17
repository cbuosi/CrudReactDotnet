using System.Data;
using Microsoft.Data.SqlClient;

public class DbConnectionFactory
{
    private readonly IConfiguration _config;

    public DbConnectionFactory(IConfiguration config)
    {
        _config = config;
    }

    public IDbConnection Create()
    {
        return new SqlConnection(
            _config.GetConnectionString("Default")
        );
    }
}