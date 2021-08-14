using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Helpers.InterceptorHelpers
{
    public static class AutofacInterceptorHelper
    {
        public static void ChangeReturnValue(IInvocation invocation, Type returnType, dynamic error,
            string message)
        {
            if (invocation.MethodInvocationTarget.ReturnType.GenericTypeArguments.Length > 0)
            {
                var typeGeneric = returnType.MakeGenericType(invocation.Method.ReturnType
                    .GenericTypeArguments[0]);
                var resultGeneric = Activator.CreateInstance(typeGeneric, error, message);

                invocation.ReturnValue = resultGeneric;
                return;
            }

            var type = returnType.MakeGenericType(typeof(object));
            var result = Activator.CreateInstance(type, error, message);

            invocation.ReturnValue = result;
        }
    }
}