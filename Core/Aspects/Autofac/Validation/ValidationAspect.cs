using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Extensions;
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
                throw new System.Exception("This is not a validation class");
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
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_errors != null)
            {
                var validationErrors = new List<string>();

                foreach (ValidationFailure error in _errors)
                {
                    validationErrors.Add(error.ErrorMessage);
                }

                if (invocation.MethodInvocationTarget.ReturnType.GenericTypeArguments.Length > 0)
                {
                    var methodName = invocation.MethodInvocationTarget.ReturnType.GenericTypeArguments[0].FullName;
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    var genericType = assembly.GetType(methodName);
                    var type = typeof(ErrorDataResult<>).MakeGenericType(genericType);
                    var result = Activator.CreateInstance(type, null,
                        "Doğrulama Hatası");

                    invocation.ReturnValue = result;
                    return;
                }

                invocation.ReturnValue =
                    new ErrorDataResult<dynamic>(new {validationErrors = validationErrors}, "Doğrulama Hatası");
            }
        }
    }
}
