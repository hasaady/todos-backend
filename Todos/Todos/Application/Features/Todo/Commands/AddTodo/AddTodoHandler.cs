using MediatR;
using Todos.Application.Interfaces.Repositories;
using Todos.Domain.Entities;

namespace Todos.Application.Features.Todo.Commands.AddTodo
{
    public class AddTodoHandler : IRequestHandler<AddTodoCommand, AddTodoResponse>
    {
        public readonly ITodosRepository _repo;

        public AddTodoHandler(ITodosRepository repo)
        {
            _repo = repo;
        }

        public async Task<AddTodoResponse> Handle(AddTodoCommand request, CancellationToken cancellationToken)
        {
            TodoEntity task = new TodoEntity
            {
                Name = request.Name,
                Description = request.Description,
                UserId = request.UsertId

            };

            await _repo.AddTaskAsync(task);

            return new AddTodoResponse();
        }
    }
}
