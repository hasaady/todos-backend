using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Authentication.Application.Models;
using Authentication.Application.Interfaces.Repositories;

namespace Authentication.Application.Features.User.Commands.Register
{
    public record RegisterRequest(string Username, [EmailAddress] string Email, string Password) : IRequest<RegisterResponse>;
    public record RegisterResponse;

    public class RegisterCommand(IUserRepository repo) : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        public IUserRepository _repo = repo;

        public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {

            if (await _repo.UserDoesExistsAsync(request.Username))
            {
                throw new NotImplementedException();
            }
            else
            {
                Models.User user = new Models.User
                {
                    Username = request.Username,
                    Email = request.Email,
                    Role = UserRole.User
                };

                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(request.Password);
                user.EncryptedPassword = Convert.ToBase64String(plainTextBytes);

                await _repo.RegisterUserAsync(user);

                return new RegisterResponse();
            }
        }
    }
}
