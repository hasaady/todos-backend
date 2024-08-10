using Authentication.Application.Models;
using Database;
using Dapper;
using System.Data;
using Authentication.Application.Interfaces.Repositories;

namespace Authentication.Infrastrucutre.Repositories
{
    public class UserRepository(IDbContext dbContext) : IUserRepository
    {
        private readonly IDbContext _dbContext = dbContext;

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                var sql = "SELECT user_id AS UserId, username AS Username, encrypted_password AS EncryptedPassword, email AS Email, role AS Role, refresh_token AS RefreshToken, expire_date AS ExpireDate FROM users WHERE username = @Username";
                return await connection.QueryFirstOrDefaultAsync<User>(sql, new { Username = username });
            }
        }

        public async Task RegisterUserAsync(User user)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                var query = "INSERT INTO public.users (username, encrypted_password, email, role) VALUES (@Username, @EncryptedPassword, @Email, @Role)";
                await connection.QueryFirstOrDefaultAsync(query, user);
            }
        }

        public async Task SaveRefreshTokenForUserAync(RefreshToken refreshToken)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                var query = "UPDATE users SET refresh_token = @Token, expire_date = @ExpireDate WHERE user_id = @Userid";
                await connection.QueryFirstOrDefaultAsync(query, refreshToken);
            }
        }

        public async Task<bool> UserDoesExistsAsync(string username)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                var query = "SELECT 1 FROM users WHERE username = @Username";
                var result = await connection.QueryFirstOrDefaultAsync(query, new { Username = username });
                return result != null;
            }
        }
    }
}
