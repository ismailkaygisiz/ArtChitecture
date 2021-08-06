using Business.Extensions.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Business.Extensions
{
    public static class TranslateMiddlewareExtensions
    {
        public static IApplicationBuilder UseTranslates(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<TranslateMiddleware>();
        }
    }
}