using Core.Business.Translate;
using Core.Utilities.Constants;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Business
{
    public class ServiceBase
    {
        protected readonly CoreMessages _coreMessages;
        protected readonly IRequestUserService _requestUserService;
        protected readonly ITranslateContext _translateContext;

        public ServiceBase()
        {
            _translateContext = ServiceTool.ServiceProvider.GetService<ITranslateContext>();
            _requestUserService = ServiceTool.ServiceProvider.GetService<IRequestUserService>();
            _coreMessages = new CoreMessages();
        }
    }
}