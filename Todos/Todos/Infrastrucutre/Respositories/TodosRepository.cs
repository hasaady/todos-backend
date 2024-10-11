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
                var query = await _sqlProvider.GetQueryAsync("add_todo.sql", GetType());

                await connection.QueryAsync(query, todo);
            }
        }

        public async Task<List<TodoEntity>> GeTodosAsync(int UserId)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                var query = await _sqlProvider.GetQueryAsync("get_todos.sql", GetType());

                await connection.QueryFistOrDefaultAsync(query, UserId);
            }
        }

        public async Task UpdateTodoAsync(TodoEntity todo)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                var query = await _sqlProvider.GetQueryAsync("udpate_todo.sql", GetType());

                await connection.QueryAsync(query, todo)
            }
        }

        public async Task DeletTodoAsync(int Id)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                var query = await _sqlProvider.GetQueryAsync("delete_todo.sql", GetType());

                await connection.QueryAsync(query, Id);
            }
        }
    }
}
