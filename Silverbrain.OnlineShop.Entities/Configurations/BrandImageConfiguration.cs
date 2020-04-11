using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Silverbrain.OnlineShop.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.Entities.Configurations
{
    public class BrandImageConfiguration : IEntityTypeConfiguration<BrandImage>
    {
        public void Configure(EntityTypeBuilder<BrandImage> builder)
        {

        }
    }
}
