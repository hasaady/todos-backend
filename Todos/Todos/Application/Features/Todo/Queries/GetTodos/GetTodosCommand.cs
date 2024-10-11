using MediatR;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Todos.Application.Features.Todo.Queries.GetTodos 
{ 
    public class GetTodosCommand: IRequest<GetTodosResponse>
    {
        public int UserId { get; set; }
    }
}
