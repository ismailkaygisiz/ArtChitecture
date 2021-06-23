using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Business;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public class RequestUserMiddleware
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RequestDelegate _next;
        private readonly IRequestUserService _requestUserService;

        public RequestUserMiddleware(RequestDelegate next)
        {
            _next = next;
            _requestUserService = ServiceTool.ServiceProvider.GetService<IRequestUserService>();
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var claims = context.User.Identities.First().Claims.ToList();

            if (claims.Count > 0)
            {
                var id = claims.Find(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var firstName = claims.Find(c => c.Type == ClaimTypes.Name).Value;
                var lastName = claims.Find(c => c.Type == ClaimTypes.Surname).Value;
                var email = claims.Find(c => c.Type == ClaimTypes.Email).Value;
                var status = claims.Find(c => c.Type == "status").Value;
                var roles = _httpContextAccessor.HttpContext.User.ClaimRoles();

                _requestUserService.SetUser(new RequestUser
                {
                    Id = int.Parse(id),
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Status = status,
                    Roles = roles
                });
            }

            await _next.Invoke(context);
        }
    }
}
