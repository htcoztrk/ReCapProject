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
            RuleFor(c=>c.DailyPrice).GreaterThan(0).WithMessage("Daily Price must be bigger than 0");
            RuleFor(c => c.CarName).MinimumLength(3).WithMessage("Car Name must be more than two chatacter.");
        }

    }
}
