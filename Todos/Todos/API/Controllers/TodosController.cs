using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todos.Api.Controllers.Base;
using Todos.Application.Features.Todo.Commands.AddTodo;

namespace Todos.Api.Controllers
{
    [Route("todo")]
    public class TodosController : ApiBaseController
    {

        private readonly ILogger<TodosController> _logger;

        private readonly IMediator _mediator;

        public TodosController(ILogger<TodosController> logger, IMediator mediator)
        {
            _logger = logger;

            _mediator = mediator;
        }

        //[HttpGet]
        //public async Task<ActionResult> Get()
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost]
        public async Task<ActionResult<AddTodoResponse>> Post(AddTodoCommand command)
        {
            command.UsertId = 1;

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        //[HttpPut]
        //public async Task<ActionResult> Put()
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpDelete]
        //public async Task<ActionResult> Delete()
        //{
        //    throw new NotImplementedException();
        //}

    }
}
