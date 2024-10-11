using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todos.Api.Controllers.Base;
using Todos.Application.Features.Todo.Commands.AddTodo;
using Todos.Application.Features.Todo.Commands.DeleteTodo;
using Todos.Application.Features.Todo.Commands.UpdateTodo;
using Todos.Application.Features.Todo.Queries.GetTodos;

namespace Todos.Api.Controllers
{
    [Route("todos")]
    public class TodosController : ApiBaseController
    {

        private readonly ILogger<TodosController> _logger;

        private readonly IMediator _mediator;

        public TodosController(ILogger<TodosController> logger, IMediator mediator)
        {
            _logger = logger;

            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await _mediator.Send(new GetTodosCommand());

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<AddTodoResponse>> Post(AddTodoCommand command)
        {
            command.UsertId = 1;

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateTodoCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteTodoCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

    }
}
