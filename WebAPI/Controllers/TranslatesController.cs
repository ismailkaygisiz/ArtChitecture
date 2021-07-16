using Business.Abstract;
using Core.API;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatesController : Controller, IControllerRepository<Translate, IActionResult>
    {
        private readonly ITranslateService _translateService;

        public TranslatesController(ITranslateService translateService)
        {
            _translateService = translateService;
        }

        [HttpPost("add")]
        public IActionResult Add(Translate entity)
        {
            var result = _translateService.Add(entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Translate entity)
        {
            var result = _translateService.Delete(entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _translateService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _translateService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbykey")]
        public IActionResult GetByKey(string key)
        {
            var result = _translateService.GetByKey(key);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbylanguageid")]
        public IActionResult GetByLanguage(int languageId)
        {
            var result = _translateService.GetByLanguageId(languageId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Translate entity)
        {
            var result = _translateService.Update(entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
