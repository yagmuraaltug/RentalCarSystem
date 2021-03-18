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
            RuleFor(p => p.CarName).MinimumLength(3);
            RuleFor(p => p.CarName).NotEmpty();
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(200);
            RuleFor(p => p.CarName).Must(StartWithA);



        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        
        }
    }
}
