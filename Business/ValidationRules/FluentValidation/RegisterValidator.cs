using Core.Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Email).EmailAddress().WithMessage("Email Gerçek Bir Email Adresi Değil");

            RuleFor(u => u.Password).MinimumLength(8).WithMessage("Parola Minimum 8 Karakter Uzunluğunda Olmalıdır");

            RuleFor(u => u.Password).Must(PasswordValidator.MustContainsLowerChar)
                .WithMessage("Parola En Az Bir Küçük Harf İçermelidir");

            RuleFor(u => u.Password).Must(PasswordValidator.MustContainsUpperChar)
                .WithMessage("Parola En Az Bir Büyük Harf İçermelidir");

            RuleFor(u => u.Password).Must(PasswordValidator.MustContainsSpecialChar)
                .WithMessage("Parola En Az Bir Özel Karakter İçermelidir");

            RuleFor(u => u.Password).Must(PasswordValidator.MustContainsNumberChar)
                .WithMessage("Parola En Az Bir Rakam İçermelidir");
        }
    }
}
