using Castle.DynamicProxy;
using Core.Business.Translate;
using Core.Utilities.Constants;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        public MethodInterception()
        {
            TranslateContext = ServiceTool.ServiceProvider.GetService<ITranslateContext>();
            CoreMessages = ServiceTool.ServiceProvider.GetService<CoreMessages>();
        }

        protected CoreMessages CoreMessages { get; }
        protected ITranslateContext TranslateContext { get; }
        protected bool Invoke { get; set; } = true;

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

            Invoke = true;
            OnAfter(invocation);
        }
    }
}