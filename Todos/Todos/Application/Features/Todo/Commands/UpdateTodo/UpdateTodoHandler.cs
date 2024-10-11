using MediatR;
using Todos.Application.Interfaces.Repositories;
using Todos.Domain.Entities;

namespace Todos.Application.Features.Todo.Commands.UpdateTodo
{
    public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand, UpdateTodoResponse>
    {
        public ITodosRepository _repo { get; set; }

        public UpdateTodoHandler(ITodosRepository todosRepository)
        {
            TodosRepository = todosRepository;
        }

        public Task<UpdateTodoResponse> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = new TodoEntity
            {
                Id = request.TaskId,
                UserId = request.UsertId
                Name = request.Name,
                Description = request.Description,
            }

           await _repo.UpdateTodoAsync(todo);

            return new UpdateTodoResponse();
        }
    }
}
