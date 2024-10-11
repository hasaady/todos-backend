using MediatR;
using Todos.Application.Interfaces.Repositories;
using Todos.Domain.Entities;

namespace Todos.Application.Features.Todo.Queries.GetTodos
{
    public class GetTodosHandler : IRequestHandler<GetTodosCommand, GetTodosResponse>
    {
        public ITodosRepository _repo;

        public GetTodosHandler(ITodosRepository repo)
        {
            _repo = repo;
        }

        public async Task<GetTodosResponse> Handle(GetTodosCommand request, CancellationToken cancellationToken)
        {
            var todos = await _repo.GeTodosAsync(request.UserId);

            return new GetTodosResponse
            {
                Todos = todos
            };
        }
    }
}
