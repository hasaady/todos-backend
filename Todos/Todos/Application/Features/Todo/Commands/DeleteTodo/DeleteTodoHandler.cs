using MediatR;
using Todos.Application.Interfaces.Repositories;

namespace Todos.Application.Features.Todo.Commands.DeleteTodo
{
    public class DeleteTodoHandler : IRequestHandler<DeleteTodoCommand, DeleteTodoResponse>
    {
        public ITodosRepository _repo { get; set; }

        public DeleteTodoHandler(ITodosRepository repo)
        {
            _repo = repo;
        }

        public async Task<DeleteTodoResponse> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            await _repo.DeletTodoAsync(request.TodoId);

            return new DeleteTodoResponse();
        }
    }
}
