using System;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.InterceptorHelpers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results.Concrete;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public TransactionScopeAspect()
        {
            Priority = 1;
        }

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
                    _ = e;
                    transactionScope.Dispose();

                    var transactionError = TranslateContext.Translates["Transaction_Error_Key"];
                    AutofacInterceptorHelper.ChangeReturnValue(invocation, typeof(TransactionScopeErrorDataResult<>),
                        transactionError, CoreMessages.TransactionScopeError());
                }
            }
        }
    }
}