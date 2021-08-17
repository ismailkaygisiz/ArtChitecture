using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;

namespace Business.Extensions.Middlewares
{
    public class UseRefreshTokenEndDateMiddleware
    {
        private readonly IAuthService _authService;
        private readonly RequestDelegate _next;

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