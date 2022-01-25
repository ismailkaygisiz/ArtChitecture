using Castle.DynamicProxy;
using Core.Utilities.Exceptions;
using Core.Utilities.Interceptors;
using System;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public TransactionScopeAspect()
        {
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
                    transactionScope.Dispose();

                    if (e.GetType() == typeof(ValidationException))
                    {
                        throw e;
                    }
                    else if (e.GetType() == typeof(AuthorizationDeniedException))
                    {
                        throw e;
                    }
                    else if (e.GetType() == typeof(LoginRequiredException))
                    {
                        throw e;
                    }
                    else
                    {
                        var transactionError = TranslateContext.Translates["Transaction_Error_Key"];
                        throw new Utilities.Exceptions.TransactionException(CoreMessages.TransactionScopeError(), transactionError);
                    }
                }
            }
        }
    }
}