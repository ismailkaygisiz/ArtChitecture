using Castle.DynamicProxy;
using Core.Business;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
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
                throw new ArgumentException("Logger can't be null");

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
            var logDetail = new LogDetail
            {
                MethodName = methodName,
                Parameters = logParameters,
                User = JsonConvert.SerializeObject(RequestUserService.GetRequestUser().Data?.Email != null ? RequestUserService.GetRequestUser().Data : null),
                FullName = (RequestUserService.GetRequestUser().Data == null ||
                            RequestUserService.GetRequestUser().Data.FirstName == null
                               ? "?"
                               : RequestUserService.GetRequestUser().Data.FirstName)
                           + " " + (RequestUserService.GetRequestUser().Data == null ||
                                    RequestUserService.GetRequestUser().Data.LastName == null
                               ? "?"
                               : RequestUserService.GetRequestUser().Data.LastName)
            };

            return JsonConvert.SerializeObject(logDetail);
        }
    }
}