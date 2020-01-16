using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SilverBrain.OnlineShop.Entities.Models;

namespace SilverBrain.OnlineShop.DataLayer
{
    class OnlineShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options)
            : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
