using System;
using Castle.DynamicProxy;
using Core.Business.Translate;
using Core.Utilities.Constants;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected CoreMessages CoreMessages { get; }
        protected ITranslateContext TranslateContext { get; }
        protected bool Invoke { get; set; } = true;

        public MethodInterception()
        {
            TranslateContext = ServiceTool.ServiceProvider.GetService<ITranslateContext>();
            CoreMessages = ServiceTool.ServiceProvider.GetService<CoreMessages>();
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
            bool isSuccess = true;
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