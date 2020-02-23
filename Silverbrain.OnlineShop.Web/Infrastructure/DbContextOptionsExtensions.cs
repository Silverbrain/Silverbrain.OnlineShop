using Microsoft.Extensions.DependencyInjection;
using Silverbrain.OnlineShop.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Silverbrain.OnlineShop.IServices;
namespace Silverbrain.OnlineShop.Web.Infrastructure
{
    public static class DbContextOptionsExtensions
    {
        //public static IServiceCollection AddConfiguredDbContext(
        //    this IServiceCollection serviceCollection, SiteSettings siteSettings)
        //{
        //    switch (siteSettings.ActiveDatabase)
        //    {
        //        case ActiveDatabase.LocalDb:
        //        case ActiveDatabase.SqlServer:
        //            serviceCollection.AddConfiguredMsSqlDbContext(siteSettings);
        //            break;
        //        default:
        //            throw new NotSupportedException("Please set the ActiveDatabase in appsettings.json file.");
        //    }

        //    return serviceCollection;
        //}

        /// <summary>
        /// Creates and seeds the database.
        /// </summary>
        public static void InitializeDb(this IServiceProvider serviceProvider)
        {
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                IIdentityDbInitializer identityDbInitialize = scope.ServiceProvider.GetRequiredService<IIdentityDbInitializer>();
                identityDbInitialize.Initialize();
                identityDbInitialize.SeedData();
            }
        }
    }
}
