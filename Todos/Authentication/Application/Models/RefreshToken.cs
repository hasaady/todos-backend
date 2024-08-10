namespace Authentication.Application.Models
{
    public class RefreshToken
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
