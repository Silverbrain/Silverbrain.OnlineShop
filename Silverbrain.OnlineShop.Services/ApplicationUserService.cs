using Silverbrain.OnlineShop.DataLayer;
using Silverbrain.OnlineShop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Services
{
    public class ApplicationUserService : GenericService<ApplicationUser, string>
    {
        public ApplicationUserService(OnlineShopDbContext dbContext) : base(dbContext)
        {

        }
    }
}
