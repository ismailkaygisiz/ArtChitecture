using Business.Abstract;
using Core.API;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupOperationClaimsController : Controller, IControllerRepository<GroupOperationClaim, IActionResult>
    {
        private readonly IGroupOperationClaimService _groupOperationClaimService;

        public GroupOperationClaimsController(IGroupOperationClaimService groupOperationClaimService)
        {
            _groupOperationClaimService = groupOperationClaimService;
        }

        [HttpPost("add")]
        public IActionResult Add(GroupOperationClaim entity)
        {
            var result = _groupOperationClaimService.Add(entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(GroupOperationClaim entity)
        {
            var result = _groupOperationClaimService.Delete(entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _groupOperationClaimService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _groupOperationClaimService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(GroupOperationClaim entity)
        {
            var result = _groupOperationClaimService.Update(entity);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
