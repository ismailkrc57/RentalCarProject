using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotNull();
            RuleFor(c => c.CarModel).NotEmpty();
            RuleFor(c => c.ColorId).NotNull();
            RuleFor(c => c.DailyPrice).NotNull();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.ModelYear).GreaterThan(DateTime.MinValue);
            RuleFor(c => c.ModelYear).NotEmpty();
        }
    }
}