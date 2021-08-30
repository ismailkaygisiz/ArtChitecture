using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class OperationClaimsController : ControllerRepository<OperationClaim>
    {
        private readonly IOperationClaimService _operationClaimService;

        public OperationClaimsController(IOperationClaimService operationClaimService) : base(operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }

        [HttpGet("[action]")]
        public IActionResult GetByName(string name)
        {
            var result = _operationClaimService.GetByName(name);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}