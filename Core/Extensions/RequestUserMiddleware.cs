using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Business;
using Microsoft.AspNetCore.Http;

namespace Core.Extensions
{
    public class RequestUserMiddleware
    {
        private readonly RequestDelegate _next;
        private IRequestUserService _requestUserService;

        public RequestUserMiddleware(RequestDelegate next, IRequestUserService requestUserService)
        {
            _next = next;
            _requestUserService = requestUserService;
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
                var roleClaims = claims.FindAll(c => c.Type == ClaimTypes.Role);
                var roles = new List<string>();

                roleClaims.ForEach(r => { roles.Add(r.Value); });

                _requestUserService.SetUser(new RequestUser()
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
