using Core.API;
using Core.Business;
using Core.Entities.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerRepository<TEntity> : ControllerBase, IControllerRepository<TEntity, IActionResult>
        where TEntity : class, IEntity, new()
    {
        private readonly IServiceRepository<TEntity> _serviceRepository;

        public ControllerRepository(IServiceRepository<TEntity> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpPost("[action]")]
        public virtual IActionResult Add(TEntity entity)
        {
            var result = _serviceRepository.Add(entity);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public virtual IActionResult Delete(TEntity entity)
        {
            var result = _serviceRepository.Delete(entity);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public virtual IActionResult GetAll()
        {
            var result = _serviceRepository.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public virtual IActionResult GetById(int id)
        {
            var result = _serviceRepository.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public virtual IActionResult Update(TEntity entity)
        {
            var result = _serviceRepository.Update(entity);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
