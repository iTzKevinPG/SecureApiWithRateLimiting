using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace SecureApiWithRateLimiting.Presentation.Configuration
{
    public static class RateLimitingConfiguration
    {
        public static void AddRateLimitingConfiguration(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.StatusCode = 429; 
                    await context.HttpContext.Response.WriteAsync("You have exceeded the limit of requests. Please try again later.", token);
                };

                // Low rate policy: For login or public endpoints
                options.AddFixedWindowLimiter("LowRate", limiterOptions =>
                {
                    limiterOptions.PermitLimit = 10;
                    limiterOptions.Window = TimeSpan.FromMinutes(1);
                });

                // Medium rate policy: For protected endpoints
                options.AddFixedWindowLimiter("MediumRate", limiterOptions =>
                {
                    limiterOptions.PermitLimit = 100;
                    limiterOptions.Window = TimeSpan.FromMinutes(1);
                });

                // High rate policy: For administrators
                options.AddFixedWindowLimiter("HighRate", limiterOptions =>
                {
                    limiterOptions.PermitLimit = 500;
                    limiterOptions.Window = TimeSpan.FromMinutes(1);
                });

                // Concurrency policy: For intensive processes
                options.AddConcurrencyLimiter("LowRateWithConcurrency", limiterOptions =>
                {
                    limiterOptions.PermitLimit = 5;
                    limiterOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    limiterOptions.QueueLimit = 2;
                });

                // Throttling policy: Limits the rate to 1 request every 500ms
                options.AddConcurrencyLimiter("Throttling", limiterOptions =>
                {
                    limiterOptions.PermitLimit = 1; 
                    limiterOptions.QueueLimit = 2; 
                    limiterOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst; 
                });
            });
        }
    }
}
