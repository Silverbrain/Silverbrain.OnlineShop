using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Services
{
    public interface IAcountManagementService
    {
        Task<SignInResult> LoginAsync(string userName, string password);
        Task LogOutAsync();
    }
}
