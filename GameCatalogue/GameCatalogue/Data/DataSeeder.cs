using GameCatalogue.Model;
using Microsoft.AspNetCore.Identity;

namespace GameCatalogue.Data
{
    public static class DataSeeder
    {
        public static async Task Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!roleManager.Roles.Any())
                {
                    var AdminRole = new IdentityRole("Admin");
                    await roleManager.CreateAsync(AdminRole);
                }

                if (!userManager.Users.Any())
                {
                    var Admin = new User("admin");
                    Admin.Email = "admin@mail.bg";

                    await userManager.CreateAsync(Admin, "P@ssw0rd123");

                    await userManager.AddToRoleAsync(Admin, "Admin");
                }

            };


        }

    }
}
