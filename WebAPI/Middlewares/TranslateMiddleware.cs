using System.Threading.Tasks;
using Business.Abstract;
using Core.Business.Translate;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

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
            if (_translateContext.Translates.Count > 0)
                return;
            _translateContext.Translates = _translateService.GetTranslates("tr-Tr").Data;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (_translateContext.Translates.Count > 0)
            {
                await _next.Invoke(context);
            }
            else
            {
                _translateContext.Translates = _translateService.GetTranslates("tr-Tr").Data;
                await _next.Invoke(context);
            }
        }
    }
}