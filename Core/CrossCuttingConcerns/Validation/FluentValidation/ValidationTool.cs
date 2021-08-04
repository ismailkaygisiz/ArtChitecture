﻿using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static List<ValidationFailure> Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);

            if (!result.IsValid) return (List<ValidationFailure>)result.Errors;

            return null;
        }
    }
}