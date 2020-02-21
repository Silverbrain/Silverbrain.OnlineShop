using Microsoft.Extensions.DependencyInjection;
using Silverbrain.OnlineShop.DataLayer;
using Silverbrain.OnlineShop.Entities.Models;
using Silverbrain.OnlineShop.IServices;
using Silverbrain.OnlineShop.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Services
{
    public static class ServiceConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IAccountManagementService), typeof(AccountManagementServiceProvider));
            services.AddTransient(typeof(IBrandService), typeof(BrandService));
        }
    }
}
