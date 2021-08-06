using Core.Business;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.Extensions.Middlewares
{
    public class RequestUserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestUserService _requestUserService;

        public RequestUserMiddleware(RequestDelegate next, IRequestUserService requestUserService)
        {
            _requestUserService = requestUserService;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
             var claims = context.User.Identities.First().Claims.ToList(); 

            if (claims.Count > 0 && context.User.Identity.IsAuthenticated)
            {
                var id = claims.Find(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var firstName = claims.Find(c => c.Type == ClaimTypes.Name).Value;
                var lastName = claims.Find(c => c.Type == ClaimTypes.Surname).Value;
                var email = claims.Find(c => c.Type == ClaimTypes.Email).Value;
                var status = claims.Find(c => c.Type == CustomClaimTypes.Status).Value;
                var roles = context.User.ClaimRoles();

                _requestUserService.RequestUser = new RequestUser
                {
                    Id = int.Parse(id),
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Status = status,
                    Roles = roles
                };
            }
            else
            {
                _requestUserService.RequestUser = null;
            }

            await _next.Invoke(context);
        }
    }
}