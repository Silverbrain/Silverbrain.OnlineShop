using Microsoft.Extensions.DependencyInjection;
using Silverbrain.OnlineShop.Repositories.Brand;
using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Repositories
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IBrandRepository), typeof(BrandRepository));
        }
    }
}
