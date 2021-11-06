using Castle.DynamicProxy;
using Core.Utilities.Exceptions;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Authorization
{
    public class LoginRequired : MethodInterception
    {
        protected override void OnBefore(IInvocation invocation)
        {
            var user = RequestUserService.GetRequestUser().Data;
            if (user.Email == null)
                throw new LoginRequiredException(CoreMessages.LoginRequired(), TranslateContext.Translates["You_Are_Redirecting_To_The_Login_Screen_Key"]);
        }
    }
}
