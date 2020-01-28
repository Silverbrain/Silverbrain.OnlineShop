using Microsoft.Extensions.DependencyInjection;
using Silverbrain.OnlineShop.Entities.Models;
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
            services.AddTransient<IAccountManagementService, AccountManagementServiceProvider>();
            services.AddTransient<IGenericRepository<Product>, GenericRepository<Product>>();
        }
    }
}
