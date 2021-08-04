using System;
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

namespace Core.Aspects.Autofac.Authorization
{
    public class SecuredOperation : MethodInterception
    {
        private readonly string _arg;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _propertyName;
        private readonly IRequestUserService _requestUserService;
        private readonly string[] _roles;

        private bool _error;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');

            _requestUserService = ServiceTool.ServiceProvider.GetService<IRequestUserService>();
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        public SecuredOperation(string roles, string arg) : this(roles)
        {
            _arg = arg;

            if (arg.Contains("."))
            {
                string[] _args;
                _args = arg.Split('.');
                _arg = _args[0];
                _propertyName = _args[1];
            }
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            if (roleClaims.Contains("Admin"))
                return;

            var parameters = invocation.Method.GetParameters();
            var parameter = parameters.Find(p => p.Name == _arg);
            dynamic methodArg = new int();

            if (invocation.Arguments != null && parameter != null)
            {
                methodArg = invocation.Arguments.GetValue(parameter.Position);
                if (_propertyName != null)
                {
                    Type myObject = methodArg.GetType();
                    methodArg = myObject.GetProperty(_propertyName).GetValue(methodArg, null);
                }

                foreach (var role in _roles)
                    if (roleClaims.Contains(role))
                        if (Control(methodArg).Success)
                            return;

                Invoke = false;
                _error = true;

                return;
            }

            foreach (var role in _roles)
                if (roleClaims.Contains(role))
                    return;

            Invoke = false;
            _error = true;
        }

        protected override void OnAfter(IInvocation invocation)
        {
            Invoke = true;
            if (_error)
            {
                _error = false;
                var securityError = TranslateContext.Translates["Cannot_Cal_Property_Error_Key"] + " : " +
                                    invocation.Method.Name;
                AutofacInterceptorHelper.ChangeReturnValue(invocation, typeof(SecurityErrorDataResult<>), securityError,
                    CoreMessages.AuthorizationDenied());
            }
        }

        private IResult Control(dynamic methodArg)
        {
            if (_requestUserService.CheckIfRequestUserIsNotEqualsUser(methodArg) != null)
                if (_requestUserService.CheckIfRequestUserIsNotEqualsUser(methodArg).Success)
                    return new SuccessResult();

            return new ErrorResult();
        }
    }
}