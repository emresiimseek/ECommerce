using ECommerce.EntityFramework.Concrete;
using FakerDotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccsess.Initilazers
{
    public class ProductInitilazers : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            for (int i = 1; i < 10; i++)
            {
                builder.HasData(new Product
                {
                    ProductId = i,
                    QuantityPerUnit = "10 packet x 1kg",
                    UnitsInStock = 100,
                    ProductName = FakerDotNet.Faker.Name.Title(),
                    UnitPrice = decimal.Parse(Faker.Number.Decimal(leftDigits: 10, rightDigits: 2)),
                    ReorderLevel= (int)Faker.Number.Positive(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,

                });
            }

        }
    }
}
