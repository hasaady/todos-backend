using MediatR;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace Todos.Application.Features.Todo.Commands.AddTodo
{
    public record AddTodoCommand: IRequest<AddTodoResponse>
    {
        [JsonIgnore]
        public int UsertId { get; set; } = 1;
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
