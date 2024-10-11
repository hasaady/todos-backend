using MediatR;
using System.Text.Json.Serialization;
using Todos.Domain.Entities;

namespace Todos.Application.Features.Todo.Commands.UpdateTodo
{
    public class UpdateTodoCommand: IRequest<UpdateTodoResponse>
    {
        [JsonIgnore]
        public int UsertId { get; set; } = 1;
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
