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

        public async Task AddTodoAsync(TodoEntity todo)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                var query = await _sqlProvider.GetQueryAsync("add_task.sql", GetType());

                await connection.QueryFirstOrDefaultAsync(query, todo);
            }
        }
    }
}
