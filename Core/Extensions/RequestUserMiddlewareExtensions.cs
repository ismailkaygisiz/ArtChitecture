using Microsoft.AspNetCore.Builder;

namespace Core.Extensions
{
    public static class RequestUserMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestUser(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestUserMiddleware>();
        }
    }
}
