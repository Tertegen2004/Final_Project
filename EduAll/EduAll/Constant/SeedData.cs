using EduAll.Domain;
using Microsoft.AspNetCore.Identity;

namespace EduAll.Constant
{
    public class SeedData
    {
        public static async Task Seeding(IServiceProvider service)
        {
            var usermanager = service.GetRequiredService<UserManager<AppUser>>();
            var rolemanager = service.GetRequiredService<RoleManager<IdentityRole>>();


            // Add Admin Role
            if (!await rolemanager.RoleExistsAsync(Roles.Admin.ToString()))
            {
                await rolemanager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            }

            // Add User Role
            if (!await rolemanager.RoleExistsAsync(Roles.User.ToString()))
            {
                await rolemanager.CreateAsync(new IdentityRole(Roles.User.ToString()));
            }

            // Add Instructor Role
            if (!await rolemanager.RoleExistsAsync(Roles.Instructor.ToString()))
            {
                await rolemanager.CreateAsync(new IdentityRole(Roles.Instructor.ToString()));
            }

            // Create Admin

            var admin = new AppUser
            {
                FirstName ="Admin",
                LastName ="Admin",
                Country ="Global",
                Email = "admin@admin.com",
                UserName = "admin@admin.com"
            };

            // Check If User Is Found
            var exist = await usermanager.FindByEmailAsync(admin.Email);

            // Create User If Not Found
            if (exist == null)
            {
                var createResult = await usermanager.CreateAsync(admin, "admin@123");

                // Add Role Admin To User
                if (createResult.Succeeded)
                {
                    await usermanager.AddToRoleAsync(admin, Roles.Admin.ToString());
                }
            }
        }
    }
}
