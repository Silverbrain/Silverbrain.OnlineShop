using Microsoft.AspNetCore.Identity;
using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.IServices;
using System.Linq;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Services
{
    public class AccountManagementServiceProvider : IAccountManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IGenericService<ApplicationUser> _repository;

        public AccountManagementServiceProvider(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IGenericService<ApplicationUser> repository)
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

        public async Task<ApplicationUser> GetAsync(string Id) =>
            await _repository.ReadAsync(Id);

        public IQueryable<ApplicationUser> GetAll() =>
            _repository.ReadAll();
    }
}