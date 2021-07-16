using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Constants;
using Core.Utilities.Helpers.InterceptorHelpers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;
        private List<ValidationFailure> _errors;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new Exception(CoreMessages.IsNotAValidationClass);

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            var notNullEntities = invocation.Arguments.Where(t => t != null);
            var entities = notNullEntities.Where(t => t.GetType() == entityType);
            foreach (var entity in entities) _errors = ValidationTool.Validate(validator, entity);

            if (_errors != null) Invoke = false;
        }

        protected override void OnAfter(IInvocation invocation)
        {
            Invoke = true;
            if (_errors != null)
            {
                var validationErrors = new List<string>();

                foreach (var error in _errors) validationErrors.Add(error.ErrorMessage);
                InterceptorHelper.ChangeReturnValue(invocation, typeof(ValidationErrorDataResult<>), validationErrors, CoreMessages.ValidationError);
            }
        }
    }
}