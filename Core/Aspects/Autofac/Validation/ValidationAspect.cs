using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Extensions;
using Core.Utilities.Constants;
using Core.Utilities.Results.Concrete;
using FluentValidation.Results;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        private List<ValidationFailure> _errors;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(CoreMessages.IsNotAValidationClass);
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator) Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            var notNullEntities = invocation.Arguments.Where(t => t != null);
            var entities = notNullEntities.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                _errors = ValidationTool.Validate(validator, entity);
            }

            if (_errors != null)
            {
                Invoke = false;
            }
        }

        protected override void OnAfter(IInvocation invocation)
        {
            Invoke = true;
            if (_errors != null)
            {
                var validationErrors = new List<string>();

                foreach (ValidationFailure error in _errors)
                {
                    validationErrors.Add(error.ErrorMessage);
                }

                if (invocation.MethodInvocationTarget.ReturnType.GenericTypeArguments.Length > 0)
                {
                    var type = typeof(ValidationErrorDataResult<>).MakeGenericType(invocation.Method.ReturnType
                        .GenericTypeArguments[0]);
                    var result = Activator.CreateInstance(type, validationErrors, CoreMessages.ValidationError);

                    invocation.ReturnValue = result;
                    return;
                }

                invocation.ReturnValue =
                    new ValidationErrorDataResult<dynamic>(validationErrors, CoreMessages.ValidationError);
                return;
            }
        }
    }
}
