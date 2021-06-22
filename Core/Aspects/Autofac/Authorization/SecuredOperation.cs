using System;
using Castle.Core.Internal;
using Castle.DynamicProxy;
using Core.Business;
using Core.Extensions;
using Core.Utilities.Constants;
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
        private bool _error;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _propertyName;
        private readonly IRequestUserService _requestUserService;
        private readonly string[] _roles;

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
            var parameters = invocation.Method.GetParameters();
            var parameter = parameters.Find(p => p.Name == _arg);
            dynamic methodArg = invocation.Arguments.GetValue(parameter.Position);

            if (_propertyName != null)
            {
                Type myObject = methodArg.GetType();
                methodArg = myObject.GetProperty(_propertyName).GetValue(methodArg, null);
            }

            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
                if (roleClaims.Contains(role))
                    if (Control(methodArg).Success)
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
                if (invocation.MethodInvocationTarget.ReturnType.GenericTypeArguments.Length > 0)
                {
                    var type = typeof(ErrorDataResult<>).MakeGenericType(invocation.Method.ReturnType
                        .GenericTypeArguments[0]);
                    var result = Activator.CreateInstance(type, null, CoreMessages.AuthorizationDenied);

                    invocation.ReturnValue = result;
                    return;
                }

                invocation.ReturnValue = new ErrorDataResult<dynamic>(null, CoreMessages.AuthorizationDenied);
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
