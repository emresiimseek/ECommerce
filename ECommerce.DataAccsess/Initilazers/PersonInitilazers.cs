using ECommerce.EntityFramework.Concrete;
using FakerDotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DataAccsess.Initilazers
{
    public class PersonInitilazers : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            for (int i = 1; i <= 5; i++)
            {
                builder.HasData(new Customer
                {
                    Id=i,
                    BirthDate=DateTime.Now,
                    CreatedOn=DateTime.Now,
                    FirstName=Faker.Name.FirstName(),
                    LastName=Faker.Name.LastName(),
                    Gender="f",
                    ModifiedOn=DateTime.Now,
                    Password=Faker.StarWars.Character(),
                    UserName=Faker.Superhero.Name(),
                    
                    
                });
            }
            for (int j = 5; j <= 10; j++)
            {
                builder.HasData(new Employee
                {
                    Id = j,
                    BirthDate = DateTime.Now,
                    CreatedOn = DateTime.Now,
                    FirstName = Faker.Name.FirstName(),
                    LastName = Faker.Name.LastName(),
                    Gender = "f",
                    ModifiedOn = DateTime.Now,
                    Password = Faker.StarWars.Character(),
                    UserName = Faker.Superhero.Name(),
                    Salary=decimal.Parse( Faker.Number.Decimal(rightDigits:2,leftDigits:5)),
                    HireDate=DateTime.Now,
                    
                });
            }

        }
    }
}
