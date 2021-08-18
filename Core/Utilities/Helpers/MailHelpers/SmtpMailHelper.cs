using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Core.Utilities.Helpers.MailHelpers
{
    public class SmtpMailHelper : IMailHelper
    {
        public SmtpMailHelper()
        {
            Configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
        }

        public IConfiguration Configuration { get; }

        public void Send(string to, string message, string subject, bool isBodyHtml = false)
        {
            SmtpMailConfiguration smtpConfiguration = Configuration.GetSection("SmtpMailConfiguration").Get<SmtpMailConfiguration>();
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                mailMessage.From = new MailAddress(smtpConfiguration.Email, smtpConfiguration.DisplayName, Encoding.UTF8);
                mailMessage.To.Add(new MailAddress(to));
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = isBodyHtml;
                mailMessage.Body = message;

                smtp.Port = smtpConfiguration.Port;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(smtpConfiguration.Email, smtpConfiguration.Password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(mailMessage);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }

    class SmtpMailConfiguration
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public int Port { get; set; }
    }
}
