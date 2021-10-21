using Core.Utilities.Constants;
using Core.Utilities.Exceptions;
using Core.Utilities.IoC;
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
                ValidationException error = (ValidationException)e;
                httpContext.Response.StatusCode = error.StatusCode;

                return httpContext.Response.WriteAsync(new ValidationErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    ErrorMessage = error.ExceptionMessage,
                    ExceptionType = error.ExceptionType,
                    ValidationErrors = error.ValidationErrors,
                }.ToString());
            }
            else if (e.GetType() == typeof(UnAuthorizedException))
            {
                UnAuthorizedException error = (UnAuthorizedException)e;
                httpContext.Response.StatusCode = error.StatusCode;

                return httpContext.Response.WriteAsync(new UnAuthorizedErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    ErrorMessage = error.ExceptionMessage,
                    ExceptionType = error.ExceptionType,
                    SecurityError = error.SecurityError,
                }.ToString());
            }
            else if (e.GetType() == typeof(TransactionException))
            {
                TransactionException error = (TransactionException)e;
                httpContext.Response.StatusCode = error.StatusCode;

                return httpContext.Response.WriteAsync(new TransactionErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    ErrorMessage = error.ExceptionMessage,
                    ExceptionType = error.ExceptionType,
                    TransactionError = error.TransactionError,
                }.ToString());
            }

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorMessage = CoreMessages.InternalServerError(),
                ExceptionType = ExceptionType.SystemException,
            }.ToString());
        }
    }
}
