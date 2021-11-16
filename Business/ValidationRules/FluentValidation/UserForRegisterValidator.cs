using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    class UserForRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).MinimumLength(5);
        }
    }
}
