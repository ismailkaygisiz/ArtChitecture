using Business.Abstract;
using Core.Business;
using Core.Extensions;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Extensions.Middlewares
{
    public class RequestUserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestUserService _requestUserService;
        private readonly IRefreshTokenService _refreshTokenService;

        public RequestUserMiddleware(RequestDelegate next)
        {
            _next = next;
            _requestUserService = ServiceTool.ServiceProvider.GetService<IRequestUserService>();
            _refreshTokenService = ServiceTool.ServiceProvider.GetService<IRefreshTokenService>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var claims = context.User.Claims.ToList();
            string token = context.Request.Headers["Authorization"];
            if (token != null && token != "" && token != "null")
            {
                var tokens = token.Split(" ");
                if (tokens.Length > 1)
                    token = tokens[1];
            }

            string refreshToken = context.Request.Headers["RefreshToken"];
            string clientId = context.Request.Headers["ClientId"];
            string clientName = context.Request.Headers["ClientName"];

            var controlRefreshToken = _refreshTokenService.GetByTokenAndRefreshTokenAndClientIdAndClientName(token, refreshToken, clientId, clientName);

            if (claims.Count > 0 && controlRefreshToken.Data != null)
            {
                var id = claims.Find(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var email = claims.Find(c => c.Type == ClaimTypes.Email).Value;
                var status = claims.Find(c => c.Type == CustomClaimTypes.Status).Value;
                var roles = context.User.ClaimRoles();

                _requestUserService.SetRequestUser(new RequestUser
                {
                    Id = int.Parse(id),
                    Email = email,
                    Status = status,
                    Roles = roles
                });
            }
            else
            {
                _requestUserService.SetRequestUser(null);
            }

            await _next.Invoke(context);
        }
    }
}