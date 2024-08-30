using System.Data;
using System.Data.SqlClient;

namespace Todos.Infrastrucutre.Database
{
    public interface ITodosDbContext
    {
        IDbConnection CreateConnection();
    }
    public class TodosDbContext : ITodosDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public TodosDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
