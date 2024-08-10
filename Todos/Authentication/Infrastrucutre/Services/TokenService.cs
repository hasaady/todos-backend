using Authentication.Application.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Authentication.Application.Interfaces.Services;

namespace Authentication.Infrastrucutre.Services
{
    public class TokenService(IConfiguration config) : ITokenService
    {
        private readonly IConfiguration _config = config;
        public string GenerateAccessToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public RefreshToken GenerateRefreshTokenForUser(User user)
        {
            var randomNumber = new byte[32];

            using (var number = RandomNumberGenerator.Create())
            {
                number.GetBytes(randomNumber);
                string refreshToken = Convert.ToBase64String(randomNumber);
                return new RefreshToken
                {
                    UserId = user.UserId,
                    Token = refreshToken,
                    ExpireDate = DateTime.Now.AddDays(6),
                };
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
    }
}
