using Core.Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginValidator : AbstractValidator<UserForLoginDto>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email Boş Olamaz");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Email Gerçek Bir Email Adresi Değil");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Parola Boş Olamaz");
        }
    }
}