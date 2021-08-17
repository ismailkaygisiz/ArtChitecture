using Core.Business.Translate;
using Core.Utilities.Constants;
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
            Configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            CoreMessages = ServiceTool.ServiceProvider.GetService<CoreMessages>();
        }

        protected IHttpContextAccessor HttpContextAccessor { get; }
        protected IRequestUserService RequestUserService { get; }
        protected ITranslateContext TranslateContext { get; }
        protected IConfiguration Configuration { get; }
        protected CoreMessages CoreMessages { get; }
    }
}