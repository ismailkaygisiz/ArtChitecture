using Castle.DynamicProxy;
using Core.Utilities.Constants;
using Core.Utilities.Helpers.InterceptorHelpers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results.Concrete;
using System;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (var transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception e)
                {
                    _ = e.Message;
                    transactionScope.Dispose();

                    string transactionError = "Beklenmedik Bir Hata Meydana Geldi Yapılan İşlem Geri ALınıyor";
                    InterceptorHelper.ChangeReturnValue(invocation, typeof(TransactionScopeErrorDataResult<>), transactionError, CoreMessages.TransactionScopeError);
                }
            }
        }
    }
}