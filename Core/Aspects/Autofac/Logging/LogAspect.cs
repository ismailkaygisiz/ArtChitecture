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
        private readonly IRequestUserService _requestUserService;

        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
                throw new ArgumentException("");

            _loggerServiceBase = (LoggerServiceBase)ServiceTool.ServiceProvider.GetService(loggerService);
            _requestUserService = ServiceTool.ServiceProvider.GetService<IRequestUserService>();
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
                User = JsonConvert.SerializeObject(_requestUserService.GetRequestUser().Data?.Email != null ? _requestUserService.GetRequestUser().Data : null),
                FullName = (_requestUserService.GetRequestUser().Data == null ||
                            _requestUserService.GetRequestUser().Data.FirstName == null
                               ? "?"
                               : _requestUserService.GetRequestUser().Data.FirstName)
                           + " " + (_requestUserService.GetRequestUser().Data == null ||
                                    _requestUserService.GetRequestUser().Data.LastName == null
                               ? "?"
                               : _requestUserService.GetRequestUser().Data.LastName)
            };

            return JsonConvert.SerializeObject(logDetail);
        }
    }
}