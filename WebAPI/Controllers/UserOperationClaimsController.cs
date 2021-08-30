using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class UserOperationClaimsController : ControllerRepository<UserOperationClaim>
    {
        private readonly IUserOperationClaimService _userOperationClaimService;

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService) : base(userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [HttpGet("[action]")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _userOperationClaimService.GetByUserId(userId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetByClaimId(int claimId)
        {
            var result = _userOperationClaimService.GetByClaimId(claimId);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}