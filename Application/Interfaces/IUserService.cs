using SecureApiWithRateLimiting.Application.DTOs;
using SecureApiWithRateLimiting.Domain.Entities;

namespace SecureApiWithRateLimiting.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse?> GetUserByIdAsync(int id);
        Task<IEnumerable<UserResponse>> GetAllUsersAsync();
        Task CreateUserAsync(CreateUserRequest user);
        Task<User?> GetUserByUsernameAsync(string username);
    }
}
