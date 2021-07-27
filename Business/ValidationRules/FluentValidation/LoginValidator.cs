using Core.Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginValidator : FluentValidator<UserForLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage(Translates["Email_Cannot_Be_Empty_Key"]);
            RuleFor(u => u.Email).EmailAddress().WithMessage(Translates["Email_Is_Not_A_Real_Email_Key"]);
            RuleFor(u => u.Password).NotEmpty().WithMessage(Translates["Password_Cannot_Be_Empty_Key"]);
        }
    }
}