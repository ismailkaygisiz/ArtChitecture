using Core.Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginValidator : AbstractValidator<UserForLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(u=>u.Email).MinimumLength(50).WithMessage("MAL");
        }
    }
}
