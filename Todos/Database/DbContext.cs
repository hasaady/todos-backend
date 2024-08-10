using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Database
{
    public interface IDbContext
    {
        IDbConnection CreateConnection();
    }

    public class DbContext : IDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
