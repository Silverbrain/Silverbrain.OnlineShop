using Microsoft.AspNetCore.Identity;
using Silverbrain.OnlineShop.DataLayer;
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
            var user = await _userManager.FindByEmailAsync(userName);

            if (user == null)
                user = await _userManager.FindByNameAsync(userName);

            return await _signInManager.PasswordSignInAsync(user, password, isPersistent, false);
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
