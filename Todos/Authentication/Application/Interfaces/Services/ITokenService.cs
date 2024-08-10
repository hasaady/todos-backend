using Authentication.Application.Models;
using System.Security.Claims;

namespace Authentication.Application.Interfaces.Services
{
    public interface ITokenService
    {
        public string GenerateAccessToken(User user);
        public RefreshToken GenerateRefreshTokenForUser(User user);
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
