using Microsoft.EntityFrameworkCore;
using SecureApiWithRateLimiting.Domain.Entities;
using SecureApiWithRateLimiting.Domain.Enums;
using System.Security.Cryptography;
using System.Text;

namespace SecureApiWithRateLimiting.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.Id);
        }
    }

    public static class AppDbContextSeed
    {
        public static async Task SeedSuperUserAsync(AppDbContext context)
        {
            if (!await context.Users.AnyAsync())
            {
                var hashedPassword = HashPassword("SuperSecurePassword123");

                var superUser = new User
                {
                    UserName = "superadmin",
                    PasswordHash = hashedPassword,
                    Role = Role.Admin.ToString()
                };

                context.Users.Add(superUser);
                await context.SaveChangesAsync();
            }
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
