using Microsoft.AspNetCore.Identity;
using Silverbrain.OnlineShop.Entities.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.IServices
{
    public interface IAccountManagementService
    {
        Task<SignInResult> LoginAsync(string userName, string password, bool isPersistent);

        Task LogOutAsync();

        Task<ApplicationUser> GetAsync(string Id);

        IQueryable<ApplicationUser> GetAll();
    }
}