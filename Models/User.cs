namespace FocusApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? UserPassword { get; set; }
        public string? Email { get; set; }
    }
}