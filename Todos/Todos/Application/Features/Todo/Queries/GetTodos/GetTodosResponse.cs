using Todos.Domain.Entities;

namespace Todos.Application.Features.Todo.Queries.GetTodos
{
    public class GetTodosResponse
    {
        public List<TodoEntity> Todos {  get; set; }
    }
}
