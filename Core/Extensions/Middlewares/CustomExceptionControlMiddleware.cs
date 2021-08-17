using System;
using System.Net;
using System.Threading.Tasks;
using Core.Utilities.Constants;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions.Middlewares
{
    public class CustomExceptionControlMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionControlMiddleware(RequestDelegate next)
        {
            _next = next;
            CoreMessages = ServiceTool.ServiceProvider.GetService<CoreMessages>();
        }

        private CoreMessages CoreMessages { get; }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = CoreMessages.InternalServerError()
            }.ToString());
            ;
        }
    }
}