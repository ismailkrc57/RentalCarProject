using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotNull();
            RuleFor(r => r.CustomerId).NotNull();
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.RentDate).NotNull();
            RuleFor(r => r.ReturnDate).GreaterThanOrEqualTo(r => r.RentDate);
        }
    }
}
