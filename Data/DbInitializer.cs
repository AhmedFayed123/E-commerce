//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Threading.Tasks;

//namespace TechXpress.Data // Adjust namespace to match your project
//{
//    public static class DbInitializer
//    {
//        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
//        {
//            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

//            string[] roles = { "Admin", "User" };

//            foreach (var role in roles)
//            {
//                if (!await roleManager.RoleExistsAsync(role))
//                {
//                    await roleManager.CreateAsync(new IdentityRole(role));
//                }
//            }

//            // Admin user details
//            string adminEmail = "admin@techxpress.com";
//            string adminPassword = "Admin123!"; // Use a strong password in production

//            var adminUser = await userManager.FindByEmailAsync(adminEmail);
//            if (adminUser == null)
//            {
//                adminUser = new IdentityUser
//                {
//                    UserName = adminEmail,
//                    Email = adminEmail,
//                    EmailConfirmed = true
//                };

//                var result = await userManager.CreateAsync(adminUser, adminPassword);
//                if (result.Succeeded)
//                {
//                    await userManager.AddToRoleAsync(adminUser, "Admin");
//                }
//            }
//            else
//            {
//                if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
//                {
//                    await userManager.AddToRoleAsync(adminUser, "Admin");
//                }
//            }
//        }
//    }
//}
