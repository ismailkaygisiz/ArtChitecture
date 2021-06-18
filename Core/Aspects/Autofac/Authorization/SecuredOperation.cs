using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System;
using System.Reflection;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Core.Aspects.Autofac.Authorization
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        private bool _error = false;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }

            _error = true;
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_error)
            {
                if (invocation.MethodInvocationTarget.ReturnType.GenericTypeArguments.Length > 0)
                {
                    var methodName = invocation.MethodInvocationTarget.ReturnType.GenericTypeArguments[0].FullName;
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    var genericType = assembly.GetType(methodName);
                    var type = typeof(ErrorDataResult<>).MakeGenericType(genericType);
                    var result = Activator.CreateInstance(type,null, "Yetkiniz Yok");

                    invocation.ReturnValue = result;
                    return;
                }

                invocation.ReturnValue = new ErrorDataResult<dynamic>(null,"Yetkiniz Yok");
            }
        }
    }
}
