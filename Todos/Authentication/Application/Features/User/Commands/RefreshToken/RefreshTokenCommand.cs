using Authentication.Application.Interfaces.Repositories;
using Authentication.Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using System.Text.Json.Serialization;

namespace Authentication.Application.Features.User.Commands.RefreshToken
{
    public record RefreshTokenRequest : IRequest<RefreshTokenResponse>
    {
        [JsonIgnore]
        public string? AccessToken { get; set; }
        public string RefreshToken {  get; set; }
    }

    public record RefreshTokenResponse(string AccessToken, string RefreshToken);

    public class RefreshTokenCommand(IUserRepository repo, ITokenService tokenService) : IRequestHandler<RefreshTokenRequest, RefreshTokenResponse>
    {
        private readonly IUserRepository _repo = repo;

        private readonly ITokenService _tokenService = tokenService;

        public async Task<RefreshTokenResponse> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);

            var username = principal.Identity.Name;

            var user = await _repo.GetUserByUsernameAsync(username);

            if (user == null)
            {
                throw new NotImplementedException();
            }

            //if (user.RefreshToken != request.RefreshToken || user.ExpireDate <= DateTime.UtcNow)
            //{
            //    throw new NotImplementedException();
            //}

            var newAccessToken = _tokenService.GenerateAccessToken(user);

            var newRefreshToken = _tokenService.GenerateRefreshTokenForUser(user);

            await _repo.SaveRefreshTokenForUserAync(newRefreshToken);

            return new RefreshTokenResponse(newAccessToken, newRefreshToken.Token);
        }
    }
}
