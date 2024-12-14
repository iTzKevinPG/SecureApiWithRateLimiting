namespace SecureApiWithRateLimiting.Application.DTOs
{
    public class LoginRequest
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
