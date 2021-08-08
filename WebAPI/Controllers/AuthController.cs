using Business.Abstract;
using Core.Business;
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
        private readonly IRequestUserService _requestUserService;
        private readonly IRefreshTokenService _refreshTokenService;

        public AuthController(IAuthService authService, IUserService userService, IRequestUserService requestUserService, IRefreshTokenService refreshTokenService)
        {
            _authService = authService;
            _userService = userService;
            _requestUserService = requestUserService;
            _refreshTokenService = refreshTokenService;
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
                    {
                        return RefreshTokenControl(user, newRefreshToken.RefreshTokenValue, refreshTokenRequest.ClientName);
                    }

                    _requestUserService.RequestUser = null;
                    return BadRequest(new ErrorResult());
                }

                return RefreshTokenControl(user, newRefreshToken.RefreshTokenValue, refreshTokenRequest.ClientName);
            }

            _requestUserService.RequestUser = null;
            return BadRequest(new ErrorResult());
        }

        private IActionResult RefreshTokenControl(User user, string refreshToken, string clientName)
        {
            var result = _authService.CreateAccessToken(user, refreshToken, clientName);
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

    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }
        public string ClientName { get; set; }
    }
}