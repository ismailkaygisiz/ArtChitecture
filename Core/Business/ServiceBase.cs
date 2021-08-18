using Core.Business.Translate;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;
using Core.Utilities.Constants;
using Core.Utilities.Helpers.MailHelpers;
using Core.Utilities.IoC;
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
            MailHelper = ServiceTool.ServiceProvider.GetService<IMailHelper>();
            Configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            FileLogger = ServiceTool.ServiceProvider.GetService<FileLogger>();
            MsSqlLogger = ServiceTool.ServiceProvider.GetService<MsSqlLogger>();
            CoreMessages = ServiceTool.ServiceProvider.GetService<CoreMessages>();
        }

        protected IHttpContextAccessor HttpContextAccessor { get; }
        protected IRequestUserService RequestUserService { get; }
        protected ITranslateContext TranslateContext { get; }
        protected IMailHelper MailHelper { get; }
        protected IConfiguration Configuration { get; }
        protected LoggerServiceBase FileLogger { get; }
        protected LoggerServiceBase MsSqlLogger { get; }
        protected CoreMessages CoreMessages { get; }
    }
}