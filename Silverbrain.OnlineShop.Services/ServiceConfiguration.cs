using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Silverbrain.OnlineShop.IServices;
using System;

namespace Silverbrain.OnlineShop.Services
{
    public static class ServiceConfiguration
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAccountManagementService), typeof(AccountManagementServiceProvider));
            services.AddScoped(typeof(IBrandService), typeof(BrandService));
            services.AddScoped<IIdentityDbInitializer, IdentityDbInitializer>();
          ///  services.AddTransient(typeof(IGenericService<int>), typeof(GenericService<>));
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