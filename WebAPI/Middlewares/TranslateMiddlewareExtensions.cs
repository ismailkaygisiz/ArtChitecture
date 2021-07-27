using Microsoft.AspNetCore.Builder;

namespace WebAPI.Middlewares
{
    public static class TranslateMiddlewareExtensions
    {
        public static IApplicationBuilder UseTranslates(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<TranslateMiddleware>();
        }
    }
}