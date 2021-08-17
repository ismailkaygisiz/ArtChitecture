using Business.Extensions.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Business.Extensions
{
    public static class CreateSuperUserMiddlewareExtensions
    {
        public static IApplicationBuilder CreateSuperUser(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<CreateSuperUserMiddleware>();
        }
    }
}