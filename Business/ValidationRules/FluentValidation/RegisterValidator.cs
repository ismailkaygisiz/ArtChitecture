using Core.Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator : FluentValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Email).EmailAddress().WithMessage(Translates["Email_Is_Not_A_Real_Email_Key"]);

            RuleFor(u => u.Password).MinimumLength(8)
                .WithMessage(Translates["Password_Must_Be_At_Least_8_Characters_Long"]);

            RuleFor(u => u.Password).Must(PasswordValidator.MustContainsLowerChar)
                .WithMessage(Translates["Password_Must_Contain_At_Least_1_Lowercase_Letter"]);

            RuleFor(u => u.Password).Must(PasswordValidator.MustContainsUpperChar)
                .WithMessage(Translates["Password_Must_Contain_At_Least_1_Uppercase_Letter"]);

            RuleFor(u => u.Password).Must(PasswordValidator.MustContainsSpecialChar)
                .WithMessage(Translates["Password_Must_Contain_At_Least_1_Special_Character"]);

            RuleFor(u => u.Password).Must(PasswordValidator.MustContainsNumberChar)
                .WithMessage(Translates["Password_Must_Contain_At_Least_1_Digit"]);
        }
    }
}