using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Application.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string EncryptedPassword { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? ExpireDate { get; set; }
    }

    public static class UserRole
    {
        public const string Admin = "admin";
        public const string User = "user";
    }

}
