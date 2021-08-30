using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class LanguagesController : ControllerRepository<Language>
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService) : base(languageService)
        {
            _languageService = languageService;
        }

        [HttpGet("[action]")]
        public IActionResult GetByName(string name)
        {
            var result = _languageService.GetByName(name);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetByCode(string code)
        {
            var result = _languageService.GetByCode(code);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}