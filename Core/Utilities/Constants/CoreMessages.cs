using System.Collections.Generic;
using Core.Business.Translate;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Constants
{
    public class CoreMessages
    {
        private ITranslateContext GetTranslateContext()
        {
            return ServiceTool.ServiceProvider.GetService<ITranslateContext>();
        }

        public string AuthorizationDenied()
        {
            return GetTranslates()["Authorization_Denied_Message_Key"];
        }

        public string ValidationError()
        {
            return GetTranslates()["Validation_Error_Message_Key"];
        }

        public string IsNotAValidationClass()
        {
            return GetTranslates()["Is_Not_A_Validation_Class_Message_Key"];
        }

        public string TransactionScopeError()
        {
            return GetTranslates()["Transaction_Scope_Error_Message_Key"];
        }

        public string InternalServerError()
        {
            return GetTranslates()["Internal_Server_Error_Key"];
        }

        private Dictionary<string, string> GetTranslates()
        {
            var Translates = GetTranslateContext().Translates;
            return Translates;
        }
    }
}