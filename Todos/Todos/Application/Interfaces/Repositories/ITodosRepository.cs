using Todos.Domain.Entities;

namespace Todos.Application.Interfaces.Repositories
{
    public interface ITodosRepository
    {
        public Task AddTaskAsync(TodoEntity task);

       //public Task<List<Task>> GetAllAsync();
    }
}
