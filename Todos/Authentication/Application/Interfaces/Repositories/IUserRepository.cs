using Authentication.Application.Models;

namespace Authentication.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task RegisterUserAsync(User user);
        Task<bool> UserDoesExistsAsync(string username);
        Task<User?> GetUserByUsernameAsync(string username);
        Task SaveRefreshTokenForUserAync(RefreshToken refreshToken);
    }
}
