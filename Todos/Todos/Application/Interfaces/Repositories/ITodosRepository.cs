using Todos.Domain.Entities;

namespace Todos.Application.Interfaces.Repositories
{
    public interface ITodosRepository
    {
        public Task AddTodoAsync(TodoEntity task);

       //public Task<List<Task>> GetAllAsync();
    }
}
