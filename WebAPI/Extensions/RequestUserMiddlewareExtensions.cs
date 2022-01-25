using Core.Extensions.Middlewares;
using Microsoft.AspNetCore.Builder;
using WebAPI.Extensions.Middlewares;

namespace WebAPI.Extensions
{
    public static class RequestUserMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestUser(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestUserMiddleware>();
        }
    }
}