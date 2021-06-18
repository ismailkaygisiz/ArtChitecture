using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OperationClaimValidator : AbstractValidator<OperationClaim>
    {
        public OperationClaimValidator()
        {
            RuleFor(o => o.Name).MinimumLength(1).WithMessage("HATA KARAKTER UZUNLUĞU EN AZ 2 OLACAK").EmailAddress().WithMessage("EMAİL OLACAK");
        }
    }
}
