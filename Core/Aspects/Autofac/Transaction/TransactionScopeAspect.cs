using Castle.DynamicProxy;
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
            using (TransactionScope transactionScope = new TransactionScope())
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

                    var transactionError = TranslateContext.Translates["Transaction_Error_Key"];
                    AutofacInterceptorHelper.ChangeReturnValue(invocation, typeof(TransactionScopeErrorDataResult<>),
                        transactionError, CoreMessages.TransactionScopeError());
                }
            }
        }
    }
}