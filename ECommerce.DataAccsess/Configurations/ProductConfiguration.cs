using ECommerce.EntityFramework.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace ECommerce.DataAccsess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.QuantityPerUnit).HasMaxLength(50);
            builder.Property(p => p.Picture).HasColumnType("blob");
        
            builder.Property(p => p.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");

            builder.Property(p => p.CreatedOn).IsRequired().HasColumnType("datetime");
            builder.Property(p => p.ModifiedOn).IsRequired().HasColumnType("datetime");

        }
    }
}
