using System.Threading.Tasks;
using Business.Abstract;
using Core.Business.Translate;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace WebAPI.Middlewares
{
    public class TranslateMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITranslateContext _translateContext;
        private readonly ITranslateService _translateService;

        public TranslateMiddleware(RequestDelegate next, ITranslateService translateService)
        {
            _next = next;
            _translateService = translateService;
            _translateContext = ServiceTool.ServiceProvider.GetService<ITranslateContext>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            StringValues lang;
            if (_translateContext.Translates.Count > 0)
            {
                if (context.Request.Headers.TryGetValue("lang", out lang))
                {
                    _translateContext.Translates = _translateService.GetTranslates(lang).Data;
                }
            }
            else
            {
                if (context.Request.Headers.TryGetValue("lang", out lang))
                {
                    _translateContext.Translates = _translateService.GetTranslates(lang).Data;
                }
                else
                {
                    _translateContext.Translates = _translateService.GetTranslates("en-Us").Data;
                }
            }

            await _next.Invoke(context);
        }
    }
}