using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Castle.DynamicProxy;
using Core.Business;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Core.Aspects.Autofac.Logging
{
    public class ExceptionLogAspect : MethodInterception
    {
        private readonly LoggerServiceBase _loggerServiceBase;
        private readonly IRequestUserService _requestUserService;

        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
                throw new ArgumentException("");

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
            _requestUserService = ServiceTool.ServiceProvider.GetService<IRequestUserService>();
        }

        protected override void OnException(IInvocation invocation, Exception e)
        {
            var logDetailWithException = GetLogDetail(invocation, e);
            logDetailWithException.ExceptionMessage = e is AggregateException
                ? string.Join(Environment.NewLine, (e as AggregateException).InnerExceptions.Select(x => x.Message))
                : e.Message;

            _loggerServiceBase.Error(JsonConvert.SerializeObject(logDetailWithException));
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation, Exception e)
        {
            var logParameters = invocation.Arguments.Select((t, i) => new LogParameter
            { Name = invocation.GetConcreteMethod().GetParameters()[i].Name, Value = t, Type = t.GetType().Name })
                .ToList();
            var methodName = invocation.MethodInvocationTarget.DeclaringType.FullName + "." + invocation.Method.Name;
            return new LogDetailWithException
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
                               : _requestUserService.GetRequestUser().Data.LastName),
                ExceptionMessage = e.Message
            };
        }
    }
}