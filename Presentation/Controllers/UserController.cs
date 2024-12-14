using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using SecureApiWithRateLimiting.Application.DTOs;
using SecureApiWithRateLimiting.Application.Interfaces;
using SecureApiWithRateLimiting.Domain.Entities;

namespace SecureApiWithRateLimiting.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "UserOrAdmin")]
        [EnableRateLimiting("MediumRate")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        [EnableRateLimiting("HighRate")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        [EnableRateLimiting("LowRate")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest userRequest)
        {
            await _userService.CreateUserAsync(userRequest);
            return CreatedAtAction(nameof(GetUserById), new { id = userRequest.UserName }, userRequest);
        }

        [HttpPost("generate-report")]
        [Authorize(Policy = "AdminOnly")] 
        [EnableRateLimiting("LowRateWithConcurrency")]
        public IActionResult GenerateReport([FromBody] string request)
        {
            Thread.Sleep(3000);
            return Ok(new { Message = "Report generated successfully!" });
        }

        [HttpPost("generate-report-throttling")]
        [Authorize(Policy = "AdminOnly")]
        [EnableRateLimiting("Throttling")]
        public IActionResult GenerateReportThrottling([FromBody] string request)
        {
            return Ok(new { Message = "Report generated successfully!" });
        }
    }
}
