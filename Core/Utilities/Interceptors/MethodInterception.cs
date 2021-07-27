﻿using System;
using Castle.DynamicProxy;
using Core.Business.Translate;
using Core.Utilities.Constants;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected readonly CoreMessages _coreMessages;
        protected readonly ITranslateContext _translateContext;
        protected bool Invoke = true;

        public MethodInterception()
        {
            _translateContext = ServiceTool.ServiceProvider.GetService<ITranslateContext>();
            _coreMessages = new CoreMessages();
        }

        protected virtual void OnBefore(IInvocation invocation)
        {
        }

        protected virtual void OnAfter(IInvocation invocation)
        {
        }

        protected virtual void OnException(IInvocation invocation, Exception e)
        {
        }

        protected virtual void OnSuccess(IInvocation invocation)
        {
        }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                if (Invoke) invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess) OnSuccess(invocation);
            }

            OnAfter(invocation);
        }
    }
}