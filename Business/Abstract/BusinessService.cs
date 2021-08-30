using Business.Constants;
using Core.Business;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Abstract
{
    public class BusinessService : ServiceBase
    {
        public BusinessService()
        {
            BusinessMessages = ServiceTool.ServiceProvider.GetService<BusinessMessages>();
        }

        protected BusinessMessages BusinessMessages { get; }
    }
}