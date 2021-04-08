using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.BrandName).MinimumLength(3);
            RuleFor(p => p.BrandName).NotEmpty();
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(200);
            RuleFor(p => p.BrandName).Must(StartWithA);



        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        
        }
    }
}
