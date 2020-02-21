using Microsoft.AspNetCore.Identity;
using Silverbrain.OnlineShop.DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.IServices
{
    public interface IAccountManagementService
    {
        Task<SignInResult> LoginAsync(string userName, string password, bool isPersistent);
        Task LogOutAsync();
        Task<ApplicationUser> GetAsync(string Id);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
    }
}
