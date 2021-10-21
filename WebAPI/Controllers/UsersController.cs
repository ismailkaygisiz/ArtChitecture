using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class UsersController : ControllerRepository<User, int>
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public IActionResult GetByEmail(string email)
        {
            var result = _userService.GetByEmail(email);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetByFirstName(string firstName)
        {
            var result = _userService.GetByFirstName(firstName);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetByLastName(string lastName)
        {
            var result = _userService.GetByLastName(lastName);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }


        [HttpGet("[action]")]
        public IActionResult GetClaims(int userId)
        {
            var result = _userService.GetUserOperationClaims(userId);

            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}