using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class TranslatesController : ControllerRepository<Translate>
    {
        private readonly ITranslateService _translateService;

        public TranslatesController(ITranslateService translateService) : base(translateService)
        {
            _translateService = translateService;
        }

        [HttpGet("[action]")]
        public IActionResult GetByKey(string key)
        {
            var result = _translateService.GetByKey(key);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetByLanguageId(int languageId)
        {
            var result = _translateService.GetByLanguageId(languageId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetTranslates(string languageCode)
        {
            var result = _translateService.GetTranslates(languageCode);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}