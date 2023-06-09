﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo((short)2023);
            RuleFor(c => c.Description).Must(StartWithTOGG).WithMessage("Araba Açıklama Metni TOGG ile Başlamalıdır!");
        }

        private bool StartWithTOGG(string arg)
        {
            return arg.StartsWith("TOGG");
        }
    }
}