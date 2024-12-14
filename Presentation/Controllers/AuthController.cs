using Microsoft.AspNetCore.Mvc;
using SecureApiWithRateLimiting.Application.DTOs;
using SecureApiWithRateLimiting.Application.Interfaces;
using SecureApiWithRateLimiting.Application.Services;
using System.Security.Cryptography;
using System.Text;

namespace SecureApiWithRateLimiting.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;
        private readonly IUserService _userService;

        public AuthController(JwtTokenService jwtTokenService, IUserService userService)
        {
            _jwtTokenService = jwtTokenService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var user = await _userService.GetUserByUsernameAsync(loginRequest.UserName);
            if (user == null || !VerifyPassword(loginRequest.Password, user.PasswordHash))
                return Unauthorized();

            var token = _jwtTokenService.GenerateToken(user);
            return Ok(new { Token = token });
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var hashedInput = Convert.ToBase64String(bytes);
            return hashedPassword == hashedInput;
        }
    }
}
