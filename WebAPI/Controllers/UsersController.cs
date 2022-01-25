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
    }
}