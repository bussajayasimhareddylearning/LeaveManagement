using leave_management.Data;
using Microsoft.AspNetCore.Identity;

namespace leave_management
{
    public static class SeedData
    {
        public static void Seed(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<Employee> userManager)
        {
            Employee employee = userManager.FindByNameAsync("ADMIN@TEST.COM").Result;
            if (employee == null)
            {
                Employee user = new Employee { UserName = "admin@test.com", Email = "admin@test.com" };
                bool success = userManager.CreateAsync(user, "Pa$$w0rd").Result.Succeeded;
                if (success)
                {
                    userManager.AddToRoleAsync(user, "Administrator");
                }
            }
        }
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                roleManager.CreateAsync(new IdentityRole { Name = "Administrator" }).Wait();
            }
            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                roleManager.CreateAsync(new IdentityRole { Name = "Employee" }).Wait();
            }
        }

    }
}
