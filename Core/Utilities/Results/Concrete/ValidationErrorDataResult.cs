using System.Collections.Generic;
using Core.Utilities.Results.Abstract;
using FluentValidation.Results;

namespace Core.Utilities.Results.Concrete
{
    public class ValidationErrorDataResult<T> : DataResult<T>
    {
        public List<string> ValidationErrors { get; }

        public ValidationErrorDataResult(List<string> validationErrors, string message) : base(default,
            false, message)
        {
            ValidationErrors = validationErrors;
        }

        public ValidationErrorDataResult(List<string> validationErrors) : base(default, false)
        {
            ValidationErrors = validationErrors;
        }

        public ValidationErrorDataResult() : base(default, false)
        {

        }
    }
}
