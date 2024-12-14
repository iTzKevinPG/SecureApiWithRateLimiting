namespace SecureApiWithRateLimiting.Application.DTOs
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
