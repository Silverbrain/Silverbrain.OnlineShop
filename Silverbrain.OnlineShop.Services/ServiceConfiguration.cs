﻿using Microsoft.AspNetCore.Identity;
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
            //services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.User.RequireUniqueEmail = false;
            });
           
        }
    }
}
