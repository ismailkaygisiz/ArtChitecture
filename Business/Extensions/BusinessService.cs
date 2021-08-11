﻿using Business.Abstract;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public class BusinessService<T> : BusinessService where T : Hub
    {
        protected IHubContext<T> HubContext { get; }

        public BusinessService()
        {
            HubContext = ServiceTool.ServiceProvider.GetService<IHubContext<T>>();
        }
    }
}
