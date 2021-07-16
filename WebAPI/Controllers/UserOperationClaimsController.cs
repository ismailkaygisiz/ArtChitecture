using Business.Abstract;
using Core.API;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : Controller, IControllerRepository<UserOperationClaim, IActionResult>
    {
        private readonly IUserOperationClaimService _userOperationClaimService;

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [HttpPost("add")]
        public IActionResult Add(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimService.Add(userOperationClaim);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimService.Delete(userOperationClaim);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimService.Update(userOperationClaim);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userOperationClaimService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userOperationClaimService.GetById(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _userOperationClaimService.GetByUserId(userId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getbyclaimid")]
        public IActionResult GetByClaimId(int claimId)
        {
            var result = _userOperationClaimService.GetByClaimId(claimId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}