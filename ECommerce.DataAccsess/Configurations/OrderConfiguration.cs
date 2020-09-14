using ECommerce.EntityFramework.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccsess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);
            builder.Property(o => o.CreatedOn).IsRequired().HasColumnType("datetime");
            builder.Property(o => o.ModifiedOn).IsRequired().HasColumnType("datetime");

        }
    }
}
