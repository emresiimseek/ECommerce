using ECommerce.EntityFramework.Concrete.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(C => C.FirstName).NotNull();
            RuleFor(C => C.LastName).NotNull();
            RuleFor(C => C.Password).NotNull();
            RuleFor(C => C.UserName).NotNull();
            RuleFor(C => C.Gender).NotNull();
        }
    }
}
