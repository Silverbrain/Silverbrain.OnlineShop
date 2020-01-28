using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasMany(p => p.Images)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.Product_Id);

            base.OnModelCreating(builder);
        }
    }
}
