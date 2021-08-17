using System.Collections.Generic;
using Core.Business.Translate;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Constants
{
    public class BusinessMessages
    {
        private ITranslateContext GetTranslateContext()
        {
            return ServiceTool.ServiceProvider.GetService<ITranslateContext>();
        }

        public string UserIsAlreadyExists()
        {
            return GetTranslates()["User_Is_Already_Exists_Key"];
        }

        public string UserIsNotExists()
        {
            return GetTranslates()["Email_Or_Password_Is_Not_Valid_Key"];
        }

        public string PasswordIsNotTrue()
        {
            return GetTranslates()["Email_Or_Password_Is_Not_Valid_Key"];
        }

        public string PasswordChanged()
        {
            return GetTranslates()["Password_Changed_Key"];
        }

        public string NewPasswordCannotBeTheSameAsTheOldPassword()
        {
            return GetTranslates()["New_Password_Cannot_Be_Same_As_The_Old_Password_Key"];
        }

        public string SuccessfulLogin()
        {
            return GetTranslates()["Successful_Login_Key"];
        }

        public string SuccessfulRegister()
        {
            return GetTranslates()["Successful_Register_Key"];
        }

        private Dictionary<string, string> GetTranslates()
        {
            var Translates = GetTranslateContext().Translates;
            return Translates;
        }
    }
}