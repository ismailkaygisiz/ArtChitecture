using Business.Abstract;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public abstract class BusinessService<T> : BusinessService where T : Hub
    {
        public BusinessService()
        {
            HubContext = ServiceTool.ServiceProvider.GetService<IHubContext<T>>();
        }

        protected IHubContext<T> HubContext { get; }
    }
}