﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silverbrain.OnlineShop.Entities.Models;

namespace Silverbrain.OnlineShop.Entities.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).HasMaxLength(50);
            builder.HasOne(b => b.Image)
                .WithOne(bi => bi.Brand)
                .HasForeignKey<BrandImage>(bi => bi.Brand_Id);
        }
    }
}