using ECommerce.EntityFramework.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccsess.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).UseMySqlIdentityColumn();
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Password).IsRequired().HasMaxLength(100);
            
            builder.Property(c => c.CreatedOn).IsRequired().HasColumnType("datetime");
            builder.Property(c => c.ModifiedOn).IsRequired().HasColumnType("datetime");

            builder.Property(c => c.BirthDate).HasColumnType("datetime");
            builder.Property(c => c.Gender).HasMaxLength(10);
        }
    }
}
