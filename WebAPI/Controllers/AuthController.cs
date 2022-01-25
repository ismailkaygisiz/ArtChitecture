using Business.Abstract;
using Core.Business;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.IoC;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebAPI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IRequestUserService _requestUserService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService, IRefreshTokenService refreshTokenService)
        {
            _authService = authService;
            _userService = userService;
            _refreshTokenService = refreshTokenService;
            _requestUserService = ServiceTool.ServiceProvider.GetService<IRequestUserService>();
        }

        [HttpPost("[action]")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var result = _authService.Register(userForRegisterDto);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public IActionResult ChangePassword(UserForLoginDto userForLoginDto, string newPassword)
        {
            var result = _authService.ChangePassword(userForLoginDto, newPassword);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("[action]")]
        public IActionResult RefreshToken()
        {
            var result = _authService.RefreshToken();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}