using SecureApiWithRateLimiting.Application.DTOs;
using SecureApiWithRateLimiting.Application.Interfaces;
using SecureApiWithRateLimiting.Domain.Entities;
using SecureApiWithRateLimiting.Infrastructure.Repository;
using System.Security.Cryptography;
using System.Text;

namespace SecureApiWithRateLimiting.Application.Services
{
    public class UserService: IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role
            };
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role
            });
        }

        public async Task CreateUserAsync(CreateUserRequest userRequest)
        {
            var hashedPassword = HashPassword(userRequest.Password);

            var user = new User
            {
                UserName = userRequest.UserName,
                PasswordHash = hashedPassword,
                Role = userRequest.Role
            };

            await _userRepository.AddAsync(user);
        }
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null) return null;

            return new User
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role,
                PasswordHash = user.PasswordHash
            };
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
