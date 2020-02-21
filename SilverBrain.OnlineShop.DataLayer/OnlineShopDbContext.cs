using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Silverbrain.OnlineShop.Entities.Configurations;
using Silverbrain.OnlineShop.Entities.Models;

namespace Silverbrain.OnlineShop.DataLayer
{
    public class OnlineShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Image> Images { get; set; }
        public DbSet<BrandImage> BrandImages { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
