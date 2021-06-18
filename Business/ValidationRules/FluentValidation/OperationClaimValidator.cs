using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OperationClaimValidator : AbstractValidator<OperationClaim>
    {
        public OperationClaimValidator()
        {
            RuleFor(o => o.Name).MinimumLength(2).WithMessage("Rol Adı Minimum 2 Karakter Uzunluğunda Olmalıdır");
        }
    }
}
