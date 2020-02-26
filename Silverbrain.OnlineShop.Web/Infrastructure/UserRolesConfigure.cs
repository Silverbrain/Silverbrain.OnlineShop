using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Silverbrain.OnlineShop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Web.Infrastructure
{
    public static class UserRolesConfigure
    {
        public static async Task AddUserWithRoles(this IApplicationBuilder app, IServiceProvider services, IConfiguration configuration)
        {
            var _roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var _userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            List<string> roles = new List<string> { "Admin" };

            foreach (string role in roles)
            {
                bool roleExist = await _roleManager.RoleExistsAsync(role);
                if (!roleExist)
                    _roleManager.CreateAsync(new IdentityRole(role)).Wait();
            }

            var _adminUser = await _userManager.FindByNameAsync("Admin");
            if (_adminUser == null)
            {
                //in oreder to change the manager username and password, change the value of ManagerUser
                //section in appsettings.json
                var adminUser = new ApplicationUser
                {
                    UserName = configuration.GetSection("ManagerUser").GetValue<string>("UserName"),
                    Email = configuration.GetSection("ManagerUser").GetValue<string>("Email")
                };
                var creatResult = await _userManager.CreateAsync(adminUser, configuration.GetSection("ManagerUser").GetValue<string>("Password"));

                if (creatResult.Succeeded)
                    await _userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
