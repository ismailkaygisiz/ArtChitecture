using Core.Extensions.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Core.Extensions
{
    public static class CustomExceptionControlMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionControlMiddleware>();
        }
    }
}
