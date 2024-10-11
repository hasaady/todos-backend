using MediatR;

namespace Todos.Application.Features.Todo.Commands.DeleteTodo
{
    public class DeleteTodoCommand: IRequest<DeleteTodoResponse>
    {
        public int UserId { get; set; }
        public int TodoId { get; set; }
    }
}
