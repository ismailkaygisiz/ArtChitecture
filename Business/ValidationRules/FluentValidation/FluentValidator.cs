﻿using Core.Business.Translate;
using Core.Utilities.IoC;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Business.ValidationRules
{
    public class FluentValidator<T> : AbstractValidator<T>
    {
        public FluentValidator()
        {
            TranslateContext = ServiceTool.ServiceProvider.GetService<ITranslateContext>();
            Translates = TranslateContext.Translates;
        }

        protected ITranslateContext TranslateContext { get; }
        protected Dictionary<string, string> Translates { get; }
    }
}