using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Silverbrain.OnlineShop.Services
{
    public class AccountManagementServiceProvider : IAcountManagementService
    {
        public Task<SignInResult> LoginAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task LogOutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
