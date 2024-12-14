using System.Security.Claims;

namespace SecureApiWithRateLimiting.Presentation.Middleware
{
    public class RoleMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                var role = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (role == null)
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("Access Denied: No Role Found.");
                    return;
                }

            }

            await _next(context); 
        }
    }
}
