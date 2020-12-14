using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using IssueTracker.Application.Enums;
using IssueTracker.Domain;

namespace IssueTracker.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles 
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }
    }
}
