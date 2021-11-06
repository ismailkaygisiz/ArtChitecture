using Core.Utilities.Constants;
using Core.Utilities.Errors;
using Core.Utilities.Exceptions;
using Core.Utilities.IoC;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Threading.Tasks;

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

            if (e.GetType() == typeof(ValidationException))
            {
                ValidationException exception = (ValidationException)e;
                httpContext.Response.StatusCode = exception.StatusCode;

                return httpContext.Response.WriteAsync(new ErrorDataResult<ValidationErrorDetails>(new ValidationErrorDetails(httpContext.Response.StatusCode, exception.ExceptionMessage, exception.ValidationErrors), exception.ExceptionMessage).ToJson());
            }
            else if (e.GetType() == typeof(LoginRequiredException))
            {
                LoginRequiredException exception = (LoginRequiredException)e;
                httpContext.Response.StatusCode = exception.StatusCode;

                return httpContext.Response.WriteAsync(new ErrorDataResult<LoginRequiredErrorDetails>(new LoginRequiredErrorDetails(httpContext.Response.StatusCode, exception.ExceptionMessage, exception.SecurityError), exception.ExceptionMessage).ToJson());
            }
            else if (e.GetType() == typeof(AuthorizationDeniedException))
            {
                AuthorizationDeniedException exception = (AuthorizationDeniedException)e;
                httpContext.Response.StatusCode = exception.StatusCode;

                return httpContext.Response.WriteAsync(new ErrorDataResult<AuthorizationDeniedErrorDetails>(new AuthorizationDeniedErrorDetails(httpContext.Response.StatusCode, exception.ExceptionMessage, exception.SecurityError), exception.ExceptionMessage).ToJson());
            }
            else if (e.GetType() == typeof(TransactionException))
            {
                TransactionException exception = (TransactionException)e;
                httpContext.Response.StatusCode = exception.StatusCode;

                return httpContext.Response.WriteAsync(new ErrorDataResult<TransactionErrorDetails>(new TransactionErrorDetails(httpContext.Response.StatusCode, exception.ExceptionMessage, exception.TransactionError), exception.ExceptionMessage).ToJson());
            }

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return httpContext.Response.WriteAsync(new ErrorDetails(httpContext.Response.StatusCode, CoreMessages.InternalServerError(), ExceptionType.SystemException).ToJson());
        }
    }
}
