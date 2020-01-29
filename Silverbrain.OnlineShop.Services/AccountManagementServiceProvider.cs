using Microsoft.AspNetCore.Identity;
using Silverbrain.OnlineShop.DataLayer;
using Silverbrain.OnlineShop.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Silverbrain.OnlineShop.Repositories;

namespace Silverbrain.OnlineShop.Services
{
    public class AccountManagementServiceProvider : IAccountManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IGenericRepository<ApplicationUser> _repository;

        public AccountManagementServiceProvider(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IGenericRepository<ApplicationUser> repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _repository = repository;
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

        public async Task<ApplicationUser> GetByIdAsync(string Id) =>
            await _repository.ReadByIdAsync(Id);

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync() =>
            await _repository.ReadAllAsync();
    }
}
