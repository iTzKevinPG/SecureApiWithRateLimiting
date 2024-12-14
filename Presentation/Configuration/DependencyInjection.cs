using SecureApiWithRateLimiting.Application.Interfaces;
using SecureApiWithRateLimiting.Application.Services;
using SecureApiWithRateLimiting.Infrastructure.Repository;

namespace SecureApiWithRateLimiting.Presentation.Configuration
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // User Configurations
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<UserRepository>();
            services.AddScoped<JwtTokenService>();

        }
    }
}
