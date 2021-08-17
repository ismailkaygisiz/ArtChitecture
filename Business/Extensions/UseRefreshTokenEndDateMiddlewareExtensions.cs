using Business.Extensions.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Business.Extensions
{
    public static class UseRefreshTokenEndDateMiddlewareExtensions
    {
        public static IApplicationBuilder UseRefreshTokenEndDate(this IApplicationBuilder applicationBuilder,
            bool useEndDate)
        {
            return applicationBuilder.UseMiddleware<UseRefreshTokenEndDateMiddleware>(useEndDate);
        }
    }
}