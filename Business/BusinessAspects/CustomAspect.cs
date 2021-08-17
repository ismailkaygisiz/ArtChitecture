using System;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Business.BusinessAspects
{
    public class CustomAspect : MethodInterception // Custom Aspect Example
    {
        protected override void OnBefore(IInvocation invocation)
        {
            base.OnBefore(invocation);
        }

        protected override void OnException(IInvocation invocation, Exception e)
        {
            base.OnException(invocation, e);
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            base.OnSuccess(invocation);
        }

        protected override void OnAfter(IInvocation invocation)
        {
            base.OnAfter(invocation);
        }
    }
}