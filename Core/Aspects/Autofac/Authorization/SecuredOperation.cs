using Castle.Core.Internal;
using Castle.DynamicProxy;
using Core.Business;
using Core.Extensions;
using Core.Utilities.Helpers.InterceptorHelpers;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Aspects.Autofac.Authorization
{
    public class SecuredOperation : MethodInterception
    {
        private IHttpContextAccessor HttpContextAccessor { get; }
        private IRequestUserService RequestUserService { get; }

        private List<string> Args { get; }
        private string Arg { get; }
        private string[] Roles { get; }
        private bool Error { get; set; }
        
        public SecuredOperation(string roles)
        {
            Priority = 2;
            Roles = roles.Split(',');

            RequestUserService = ServiceTool.ServiceProvider.GetService<IRequestUserService>();
            HttpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        public SecuredOperation(string roles, string arg) : this(roles)
        {
            Arg = arg;

            if (arg.Contains("."))
            {
                Args = arg.Split('.').ToList();
                Arg = Args[0];

                var argToDel = Args.SingleOrDefault(a => a == Arg);
                Args.Remove(argToDel);
            }
            else
            {
                Args = new List<string>();
            }
        }

        protected override void OnBefore(IInvocation invocation)
        {
            List<string> roleClaims = RequestUserService.RequestUser?.Roles;
            if (roleClaims == null)
            {
                Invoke = false;
                Error = true;
                return;
            }

            if (roleClaims.Contains("Admin"))
                return;

            var parameters = invocation.Method.GetParameters();
            var parameter = parameters.Find(p => p.Name == Arg);

            dynamic methodArg = new int();

            if (invocation.Arguments != null && parameter != null)
            {
                methodArg = invocation.Arguments.GetValue(parameter.Position);
                Type entity = methodArg.GetType();

                int index = 0;
                foreach (var arg in Args)
                {
                    if (index == 0)
                        methodArg = entity.GetProperty(arg).GetValue(methodArg, null);
                    else
                        methodArg = methodArg.GetType().GetProperty(arg).GetValue(methodArg, null);

                    index++;
                }

                foreach (var role in Roles)
                    if (roleClaims.Contains(role))
                        if (Control(methodArg).Success)
                            return;

                Invoke = false;
                Error = true;
                return;
            }

            foreach (var role in Roles)
                if (roleClaims.Contains(role))
                    return;

            Invoke = false;
            Error = true;
        }

        protected override void OnAfter(IInvocation invocation)
        {
            Invoke = true;
            if (Error)
            {
                Error = false;
                var securityError = TranslateContext.Translates["Cannot_Cal_Property_Error_Key"] + " : " +
                                    invocation.Method.Name;
                AutofacInterceptorHelper.ChangeReturnValue(invocation, typeof(SecurityErrorDataResult<>), securityError,
                    CoreMessages.AuthorizationDenied());
            }
        }

        private IResult Control(dynamic methodArg)
        {
            if (RequestUserService.CheckIfRequestUserIsNotEqualsUser(methodArg) != null)
                if (RequestUserService.CheckIfRequestUserIsNotEqualsUser(methodArg).Success)
                    return new SuccessResult();

            return new ErrorResult();
        }
    }
}