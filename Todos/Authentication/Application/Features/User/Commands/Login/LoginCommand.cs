using Authentication.Application.Interfaces.Repositories;
using Authentication.Application.Interfaces.Services;
using MediatR;
using System.Net;

namespace Authentication.Application.Features.User.Commands.Login
{
    public record LoginRequest(string Username, string Password) : IRequest<LoginResponse>;

    public record LoginResponse(string Token, string RefreshToken);

    public class LoginCommand(IUserRepository repo, ITokenService tokenService) : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IUserRepository _repo = repo;

        private readonly ITokenService _tokenService = tokenService;

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await GetUser(request.Username, request.Password);

            var accessToken = _tokenService.GenerateAccessToken(user);

            var refreshToken = _tokenService.GenerateRefreshTokenForUser(user);

            await _repo.SaveRefreshTokenForUserAync(refreshToken);

            return new LoginResponse(accessToken, refreshToken.Token);
        }

        private async Task<Models.User> GetUser(string username, string password)
        {
            var user = await _repo.GetUserByUsernameAsync(username);

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
            string encryptedPassword = Convert.ToBase64String(plainTextBytes);

            if (user == null && user.EncryptedPassword != encryptedPassword)
            {
                throw new NotImplementedException();
            }

            return user;
        }
    }
}
