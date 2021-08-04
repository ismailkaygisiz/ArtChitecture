using System.Collections.Generic;
using Core.Business.Translate;
using Core.Utilities.IoC;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Business.ValidationRules
{
    public class FluentValidator<T> : AbstractValidator<T>
    {
        protected ITranslateContext TranslateContext { get; }

        public FluentValidator()
        {
            TranslateContext = ServiceTool.ServiceProvider.GetService<ITranslateContext>();
            Translates = TranslateContext.Translates;
        }

        protected Dictionary<string, string> Translates { get; }
    }
}