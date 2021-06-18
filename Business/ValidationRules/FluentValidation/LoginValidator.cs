using Core.Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginValidator : AbstractValidator<UserForLoginDto>
    {
        public LoginValidator()
        {
        }
    }
}
