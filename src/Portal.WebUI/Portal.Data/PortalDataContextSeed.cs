using Microsoft.AspNetCore.Identity;
using Portal.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Data
{
    public class PortalDataContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var rolelist = new List<IdentityRole>();
            rolelist.Add(new IdentityRole("Administrator"));
            rolelist.Add(new IdentityRole("Clerk"));


            foreach(var role in rolelist)
            {
                if(roleManager.Roles.All(r=>r.Name!=role.Name))
                {
                    await roleManager.CreateAsync(role);
                }
            }

            var administrator = new ApplicationUser { UserName = "administrator@portal.com", Email = "administrator@portal.com",FirstName="Admin",LastName="Admin" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1!");
                await userManager.AddToRolesAsync(administrator, new[] { "Administrator" });
            }

            var clerk = new ApplicationUser { UserName = "clerk@portal.com", Email = "clerk@portal.com", FirstName = "Clerk", LastName = "Clerk" };

            if (userManager.Users.All(u => u.UserName != clerk.UserName))
            {
                await userManager.CreateAsync(clerk, "Clerk1!");
                await userManager.AddToRolesAsync(clerk, new[] { "Clerk" });
            }
        }
    }
}
