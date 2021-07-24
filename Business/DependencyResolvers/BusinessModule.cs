using Business.Hubs;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers
{
    public class BusinessModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSignalR();
            serviceCollection.AddTransient<SystemHub>();
        }
    }
}