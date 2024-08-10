using Authentication.Api.Controllers.Base;
using Authentication.Application.Features.User.Commands.Login;
using Authentication.Application.Features.User.Commands.RefreshToken;
using Authentication.Application.Features.User.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Authentication.Api.Controllers
{
    [Route("user")]
    public class UserController(ILogger<UserController> logger, IMediator mediator) : ApiController
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly IMediator _mediator = mediator;

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("refreshToken")]
        [Authorize]
        public async Task<ActionResult<RefreshTokenResponse>> RefreshToken(RefreshTokenRequest request)
        {

            var accessToken = Request.Headers[HeaderNames.Authorization]
                .ToString()
                .Substring("Bearer ".Length)
                .Trim();

            request.AccessToken = accessToken;

            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
