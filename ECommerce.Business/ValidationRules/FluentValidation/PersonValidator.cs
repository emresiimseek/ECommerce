using ECommerce.EntityFramework.Concrete.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Business.ValidationRules.FluentValidation
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(u => u.UserName).NotNull();
            RuleFor(u => u.Password).NotNull();
        }
    }
}
