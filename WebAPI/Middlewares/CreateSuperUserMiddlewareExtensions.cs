using Microsoft.AspNetCore.Builder;

namespace WebAPI.Middlewares
{

    public static class CreateSuperUserMiddlewareExtensions
    {
        public static IApplicationBuilder CreateSuperUser(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<CreateSuperUserMiddleware>();
        }
    }

}
