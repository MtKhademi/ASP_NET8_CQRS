using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Api.Utilities
{
    public static class SeedInitializer
    {
        public static async Task RoleInitializeAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
        public static async Task AdminInitilizeAsync(UserManager<IdentityUser> userManager)
        {
            var admin = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                FullName = "administator",
                EmailConfirmed = true
            };

            if(await userManager.FindByEmailAsync(admin.Email) == null)
            {
                await userManager.CreateAsync(admin, "123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

        }
    }
}
