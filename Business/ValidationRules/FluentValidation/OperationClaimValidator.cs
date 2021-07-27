using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OperationClaimValidator : FluentValidator<OperationClaim>
    {
        public OperationClaimValidator()
        {
            RuleFor(o => o.Name).MinimumLength(2)
                .WithMessage(Translates["Role_Name_Must_Be_At_Least_2_Characters_Long"]);
        }
    }
}