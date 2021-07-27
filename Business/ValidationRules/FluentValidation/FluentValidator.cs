using System.Collections.Generic;
using Core.Business.Translate;
using Core.Utilities.IoC;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Business.ValidationRules
{
    public class FluentValidator<T> : AbstractValidator<T>
    {
        protected readonly ITranslateContext _translateContext;

        public FluentValidator()
        {
            _translateContext = ServiceTool.ServiceProvider.GetService<ITranslateContext>();
            Translates = _translateContext.Translates;
        }

        protected Dictionary<string, string> Translates { get; }
    }
}