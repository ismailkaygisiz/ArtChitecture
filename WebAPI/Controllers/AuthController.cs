using System;
using Business.Abstract;
using Core.Business;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.IoC;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IRequestUserService _requestUserService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService,
            IRefreshTokenService refreshTokenService)
        {
            _authService = authService;
            _userService = userService;
            _refreshTokenService = refreshTokenService;
            _requestUserService = ServiceTool.ServiceProvider.GetService<IRequestUserService>();
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
        public IActionResult RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            var newRefreshToken = _refreshTokenService.GetByRefreshToken(refreshTokenRequest.RefreshToken).Data;
            if (newRefreshToken != null)
            {
                var user = _userService.GetByIdForAuth(newRefreshToken.UserId).Data;
                if (_authService.UseRefreshTokenEndDate)
                {
                    if (newRefreshToken.RefreshTokenEndDate > DateTime.Now)
                        return RefreshTokenControl(user, refreshTokenRequest);

                    _requestUserService.SetRequestUser(null);
                    return BadRequest(new ErrorResult());
                }

                return RefreshTokenControl(user, refreshTokenRequest);
            }

            _requestUserService.SetRequestUser(null);
            return BadRequest(new ErrorResult());
        }

        private IActionResult RefreshTokenControl(User user, RefreshTokenRequest refreshToken)
        {
            var result = _authService.CreateAccessToken(user, refreshToken.RefreshToken, refreshToken.ClientName,
                refreshToken.ClientId);
            if (result.Success) return Ok(result);

            _requestUserService.SetRequestUser(null);
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

    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
    }
}