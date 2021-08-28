using Business.Helpers;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Business.Extensions.Middlewares
{
    public class UseRefreshTokenEndDateMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRefreshTokenHelper _refreshTokenHelper;

        public UseRefreshTokenEndDateMiddleware(RequestDelegate next, IRefreshTokenHelper refreshTokenHelper, bool useEndDate)
        {
            _next = next;
            _refreshTokenHelper = refreshTokenHelper;
            _refreshTokenHelper.UseRefreshTokenEndDate = useEndDate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
        }
    }
}