using Microsoft.Extensions.Configuration;

namespace Core.Utilities.Helpers.MailHelpers
{
    public interface IMailHelper
    {
        IConfiguration Configuration { get; }
        void Send(string to, string message, string subject, bool isBodyHtml = false);
    }
}