using Core.Business.Translate;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Constants;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Helpers.MailHelpers;
using Core.Utilities.IoC;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Business
{
    public class ServiceBase
    {
        public ServiceBase()
        {
            HttpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            RequestUserService = ServiceTool.ServiceProvider.GetService<IRequestUserService>();
            TranslateContext = ServiceTool.ServiceProvider.GetService<ITranslateContext>();

            UserTokenHelper = ServiceTool.ServiceProvider.GetService<ITokenHelper<User>>();
            MailHelper = ServiceTool.ServiceProvider.GetService<IMailHelper>();
            FileHelper = ServiceTool.ServiceProvider.GetService<IFileHelper>();

            Configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();

            FileLogger = ServiceTool.ServiceProvider.GetService<FileLogger>();
            MsSqlLogger = ServiceTool.ServiceProvider.GetService<MsSqlLogger>();

            CoreMessages = ServiceTool.ServiceProvider.GetService<CoreMessages>();
        }

        public IHttpContextAccessor HttpContextAccessor { get; }
        public IRequestUserService RequestUserService { get; }
        public ITranslateContext TranslateContext { get; }

        public ITokenHelper<User> UserTokenHelper { get; }
        public IMailHelper MailHelper { get; }
        public IFileHelper FileHelper { get; }

        public IConfiguration Configuration { get; }

        public LoggerServiceBase FileLogger { get; }
        public LoggerServiceBase MsSqlLogger { get; }

        public CoreMessages CoreMessages { get; }
    }
}