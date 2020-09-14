using ECommerce.EntityFramework.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccsess.Configurations
{
    public class ShipperConfiguration : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.HasKey(s => s.ShipperId);
            builder.Property(s => s.Phone).HasMaxLength(20);
            builder.Property(s => s.CompanyName).HasMaxLength(50);
            builder.Property(s => s.CreatedOn).IsRequired().HasColumnType("datetime");
            builder.Property(s => s.ModifiedOn).IsRequired().HasColumnType("datetime");

        }
    }
}
