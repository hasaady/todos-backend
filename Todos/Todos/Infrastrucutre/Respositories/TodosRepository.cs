using Dapper;
using Todos.Infrastrucutre.Database;
using System.Data;
using Todos.Application.Interfaces.Repositories;
using Todos.Domain.Entities;
using Utility.Providers;

namespace Todos.Infrastrucutre.Respositories
{
    public class TodosRepository : ITodosRepository
    {
        private readonly ITodosDbContext _dbContext;

        private readonly ISQLQueryProvider _sqlProvider;
        public TodosRepository(ITodosDbContext dbContext, ISQLQueryProvider sqlProvider)
        {
            _dbContext = dbContext;
            _sqlProvider = sqlProvider;
        }

        public async Task AddTaskAsync(TodoEntity task)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                var query = await _sqlProvider.GetQuery("Add_task.sql");
                await connection.ExecuteAsync(query, task);
            }
        }
    }
}
