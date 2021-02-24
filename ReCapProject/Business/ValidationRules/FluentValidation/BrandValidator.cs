using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).MinimumLength(2).WithMessage("Brand Name cannot be less than two character.");
            RuleFor(b => b.BrandName).NotEmpty();
            //RuleFor(b => b.Uniteprice).GreaterThan(0);
            //RuleFor(b => b.BrandId).GreaterThanOrEqualTo(10).When(b => b.BrandId == 1);

            //şimdi olmayan bir kuralı biz kendimiz yazalım:StartWithA bizim methodumuz
            RuleFor(b => b.BrandName).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
