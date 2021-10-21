using Business.Abstract;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        public BusinessService BusinessService { get; set; }
        public Controller()
        {
            BusinessService = ServiceTool.ServiceProvider.GetService<BusinessService>();
        }
    }
}
