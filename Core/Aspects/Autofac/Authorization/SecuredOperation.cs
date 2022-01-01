using Castle.Core.Internal;
using Castle.DynamicProxy;
using Core.Utilities.Exceptions;
using Core.Utilities.Interceptors;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Aspects.Autofac.Authorization
{
    public class SecuredOperation : MethodInterception
    {
        private readonly string[] _roles;
        private readonly List<string> _args;
        private readonly string _arg;

        public SecuredOperation(string roles)
        {
            Priority = 2;
            _roles = roles.Split(',');
        }

        public SecuredOperation(string roles, string arg) : this(roles)
        {
            _arg = arg;

            if (arg.Contains("."))
            {
                _args = arg.Split('.').ToList();
                _arg = _args[0];

                var argToDel = _args.SingleOrDefault(a => a == _arg);
                _args.Remove(argToDel);
            }
            else
            {
                _args = new List<string>();
            }
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = RequestUserService.GetRequestUser().Data?.Roles;
            if (roleClaims == null)
                ThrowError(invocation);

            if (roleClaims.Contains("Admin"))
                return;

            var parameters = invocation.Method.GetParameters();
            var parameter = parameters.Find(p => p.Name == _arg);
            dynamic methodArg = 0;

            if (invocation.Arguments != null && parameter != null)
            {
                methodArg = invocation.Arguments.GetValue(parameter.Position);
                Type entity = methodArg.GetType();

                var index = 0;
                foreach (var arg in _args)
                {
                    if (index == 0)
                        methodArg = entity.GetProperty(arg).GetValue(methodArg, null);
                    else
                        methodArg = methodArg.GetType().GetProperty(arg).GetValue(methodArg, null);

                    index++;
                }

                foreach (var role in _roles)
                {
                    if (role == "")
                        if (Control(methodArg).Success)
                            return;

                    if (roleClaims.Contains(role))
                        if (Control(methodArg).Success)
                            return;
                }
                ThrowError(invocation);
            }

            foreach (var role in _roles)
                if (roleClaims.Contains(role))
                    return;

            ThrowError(invocation);
        }

        private IResult Control(dynamic methodArg)
        {
            if (RequestUserService.CheckIfRequestUserIsNotEqualsUser(methodArg) != null)
                if (RequestUserService.CheckIfRequestUserIsNotEqualsUser(methodArg).Success)
                    return new SuccessResult();

            return new ErrorResult();
        }

        private void ThrowError(IInvocation invocation)
        {
            var securityError = TranslateContext.Translates["Cannot_Cal_Property_Error_Key"] + " : " +
                                invocation.Method.Name;

            throw new AuthorizationDeniedException(CoreMessages.AuthorizationDenied(), securityError);
        }
    }
}
