using Microsoft.AspNetCore.Identity;
using SilverBrain.OnlineShop.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Services
{
    public class AccountManagementServiceProvider : IAccountManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountManagementServiceProvider(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<SignInResult> LoginAsync(string userName, string password, bool isPersistent)
        {
            var user = await _userManager.FindByNameAsync(userName);
            
            if(user != null)
            {
                var inRole = await _userManager.IsInRoleAsync(user, "Admin");
                
                if(inRole)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent, false);
                    if (result.Succeeded)
                        return result;
                }
            }
            return await _signInManager.PasswordSignInAsync(user, password, isPersistent, false);
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
