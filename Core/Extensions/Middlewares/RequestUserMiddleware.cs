using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Business;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions.Middlewares
{
    public class RequestUserMiddleware
    {
        private readonly IRequestUserService _requestUserService;
        private readonly RequestDelegate _next;

        public RequestUserMiddleware(RequestDelegate next)
        {
            _requestUserService = ServiceTool.ServiceProvider.GetService<IRequestUserService>();
            _next = next;
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
                var roles = context.User.ClaimRoles();

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
