using Business.Abstract;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Business.Extensions.Middlewares
{
    public class UseRefreshTokenEndDateMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAuthService _authService;

        public UseRefreshTokenEndDateMiddleware(RequestDelegate next, IAuthService authService, bool useEndDate)
        {
            _next = next;
            _authService = authService;
            _authService.UseRefreshTokenEndDate = useEndDate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
        }
    }
}
