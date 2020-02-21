using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Silverbrain.OnlineShop.DataLayer
{
    class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(au => au.FirstName).HasMaxLength(50);
            builder.Property(au => au.LastName).HasMaxLength(50);
        }
    }
}
