using Todos.Domain.Entities;

namespace Todos.Application.Interfaces.Repositories
{
    public interface ITodosRepository
    {
       public Task AddTodoAsync(TodoEntity todo);

       public Task<List<TodoEntity>> GeTodosAsync(int UserId);

       public Task DeletTodoAsync(int Id);

       public Task UpdateTodoAsync(TodoEntity todo);
    }
}
