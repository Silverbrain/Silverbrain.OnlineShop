using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silverbrain.OnlineShop.Entities.Models;

namespace Silverbrain.OnlineShop.Entities.Configurations
{
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title).IsRequired().HasMaxLength(50);
            builder.Property(s => s.ImageBig).IsRequired();
            builder.Property(s => s.ImageSmall).IsRequired();
            builder.Property(s => s.LandingURL).HasMaxLength(70);
        }
    }
}