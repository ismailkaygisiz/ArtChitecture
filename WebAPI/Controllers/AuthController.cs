using Business.Abstract;
using Core.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto);
            if (result.Success)
            {
                return Ok(_authService.CreateAccessToken(_authService.GetUser().Data));
            }

            return BadRequest(result);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var result = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            if (result.Success)
            {
                return Ok(_authService.CreateAccessToken(_authService.GetUser().Data));
            }

            return BadRequest(result);
        }

        [HttpPost("changepassword")]
        public IActionResult ChangePassword(UserForLoginDto userForLoginDto, string newPassword)
        {
            var result = _authService.ChangePassword(userForLoginDto, newPassword);
            if (result.Success)
            {
                return Ok(_authService.CreateAccessToken(_authService.GetUser().Data));
            }

            return BadRequest(result);
        }
    }
}
