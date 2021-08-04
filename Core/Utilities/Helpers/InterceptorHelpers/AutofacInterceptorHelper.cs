﻿using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Helpers.InterceptorHelpers
{
    public static class AutofacInterceptorHelper
    {
        public static void ChangeReturnValue(IInvocation invocation, Type returnType, dynamic errorMessage,
            string message)
        {
            if (invocation.MethodInvocationTarget.ReturnType.GenericTypeArguments.Length > 0)
            {
                var typeGeneric = returnType.MakeGenericType(invocation.Method.ReturnType
                    .GenericTypeArguments[0]);
                var resultGeneric = Activator.CreateInstance(typeGeneric, errorMessage, message);

                invocation.ReturnValue = resultGeneric;
                return;
            }

            var type = returnType.MakeGenericType(typeof(object));
            var result = Activator.CreateInstance(type, errorMessage, message);

            invocation.ReturnValue = result;
        }
    }
}