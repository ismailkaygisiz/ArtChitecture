using Business.Concrete;
using Business.Constants;
using Core.Business;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public class BusinessService<T> : BusinessService where T : Hub, new()
    {
        protected IHubContext<T> HubContext { get; }

        public BusinessService()
        {
            HubContext = ServiceTool.ServiceProvider.GetService<IHubContext<T>>();
        }
    }
}
