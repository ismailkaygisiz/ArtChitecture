using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var result = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("refreshtoken")]
        public IActionResult RefreshToken(string refreshToken)
        {
            var user = _userService.GetByRefreshToken(refreshToken);
            if (user.Data != null)
            {
                if (_authService.UseRefreshTokenEndDate)
                {
                    if (user.Data.RefreshTokenEndDate > DateTime.Now)
                    {
                        return RefreshTokenControl(user.Data);
                    }

                    return BadRequest(new ErrorResult());
                }

                return RefreshTokenControl(user.Data);
            }

            return BadRequest(new ErrorResult());
        }

        private IActionResult RefreshTokenControl(User user)
        {
            var result = _authService.CreateAccessToken(user);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("changepassword")]
        public IActionResult ChangePassword(UserForLoginDto userForLoginDto, string newPassword)
        {
            var result = _authService.ChangePassword(userForLoginDto, newPassword);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}