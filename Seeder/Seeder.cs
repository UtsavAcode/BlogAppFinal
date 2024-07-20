using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Seeder
{
    public class Seeder
    {
        private static Guid adminRoleId;
        private static Guid userRoleId;
        private static Guid superAdminRoleId;

        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedRoles(modelBuilder);
            SeedDefaultAdminUser(modelBuilder);
        }

        public static void SeedRoles(ModelBuilder modelBuilder)
        {
            superAdminRoleId = Guid.NewGuid();
            adminRoleId = Guid.NewGuid();
            userRoleId = Guid.NewGuid();

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = superAdminRoleId.ToString(),
                    Name = "SuperAdmin",
                    ConcurrencyStamp = "1",
                    NormalizedName = "SUPERADMIN"
                },
                new IdentityRole()
                {
                    Id = adminRoleId.ToString(),
                    Name = "Admin",
                    ConcurrencyStamp = "2",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Id = userRoleId.ToString(),
                    Name = "User",
                    ConcurrencyStamp = "3",
                    NormalizedName = "USER"
                }
            );
        }

        public static void SeedDefaultAdminUser(ModelBuilder modelBuilder)
        {
            var userId = Guid.NewGuid();

            var user = new IdentityUser
            {
                Id = userId.ToString(),
                UserName = "SuperAdmin",
                NormalizedUserName = "SUPERADMIN",
                Email = "superadmin@gmail.com",
                NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                LockoutEnabled = true
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");

            modelBuilder.Entity<IdentityUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = userId.ToString(),
                    RoleId = superAdminRoleId.ToString()
                }
            );
        }
    }
}
