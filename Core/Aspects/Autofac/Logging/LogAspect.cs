using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private readonly LoggerServiceBase _loggerServiceBase;

        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
                throw new ArgumentException();

            _loggerServiceBase = (LoggerServiceBase)ServiceTool.ServiceProvider.GetService(loggerService);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase?.Info(GetLogDetail(invocation));
        }

        private string GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (var i = 0; i < invocation.Arguments.Length; i++)
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });

            var methodName = invocation.MethodInvocationTarget.DeclaringType.FullName + "." + invocation.Method.Name;

            var requestUser = RequestUserService.GetRequestUser().Data;
            var logDetail = new LogDetail
            {
                MethodName = methodName,
                Parameters = logParameters,
                User = JsonConvert.SerializeObject(requestUser?.Email != null ? requestUser : null),
                Email = (requestUser.Email == null
                               ? "?"
                               : requestUser?.Email)
            };

            return JsonConvert.SerializeObject(logDetail);
        }
    }
}