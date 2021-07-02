using Castle.DynamicProxy;
using Core.Utilities.Constants;
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

                    if (invocation.MethodInvocationTarget.ReturnType.GenericTypeArguments.Length > 0)
                    {
                        var type = typeof(TransactionScopeErrorDataResult<>).MakeGenericType(invocation.Method.ReturnType
                            .GenericTypeArguments[0]);
                        var result = Activator.CreateInstance(type, transactionError, CoreMessages.TransactionScopeError);

                        invocation.ReturnValue = result;
                        return;
                    }

                    invocation.ReturnValue =
                        new TransactionScopeErrorDataResult<dynamic>(transactionError, CoreMessages.TransactionScopeError);
                }
            }
        }
    }
}