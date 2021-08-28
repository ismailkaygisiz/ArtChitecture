using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Cryptography;

namespace Business.Helpers
{
    public class RefreshTokenHelper : BusinessService, IRefreshTokenHelper
    {
        private readonly IRefreshTokenService _refreshTokenService;
        private string _refreshToken;
        private string _clientId;
        private string _clientName;

        public RefreshTokenHelper(IRefreshTokenService refreshTokenService)
        {
            _refreshTokenService = refreshTokenService;
        }

        public bool UseRefreshTokenEndDate { get; set; }

        public string CreateRefreshToken()
        {
            var number = new byte[32];
            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }

        public void CreateDifferentRefreshToken(RefreshToken refreshToken)
        {
            while (_refreshTokenService.GetByRefreshToken(refreshToken.RefreshTokenValue).Data != null)
                refreshToken.RefreshTokenValue = CreateRefreshToken();

            if (UseRefreshTokenEndDate)
                refreshToken.RefreshTokenEndDate = DateTime.Now.AddMinutes(Configuration.GetSection("TokenOptions")
                    .Get<TokenOptions>().RefreshTokenExpiration);
            else
                refreshToken.RefreshTokenEndDate = null;
        }

        public RefreshToken CreateNewRefreshToken(User user)
        {
            _clientId = HttpContextAccessor.HttpContext.Request.Headers["ClientId"];
            _clientName = HttpContextAccessor.HttpContext.Request.Headers["ClientName"];

            if (!Control(_clientId))
            {
                _clientId = Guid.NewGuid().ToString();
                while (_refreshTokenService.GetByClientId(_clientId).Data != null) _clientId = Guid.NewGuid().ToString();
            }

            var newRefreshToken = new RefreshToken
            {
                UserId = user.Id,
                User = new User()
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Status = user.Status
                },
                ClientName = _clientName,
                ClientId = _clientId,
                RefreshTokenValue = CreateRefreshToken(),
            };

            CreateDifferentRefreshToken(newRefreshToken);
            var oldRefreshToken = _refreshTokenService.GetByClientId(_clientId).Data;

            if (oldRefreshToken != null)
            {
                newRefreshToken.Id = oldRefreshToken.Id;
                _refreshTokenService.Update(newRefreshToken);
            }
            else
            {
                _refreshTokenService.Add(newRefreshToken);
            }

            return newRefreshToken;
        }

        public RefreshToken UpdateOldRefreshToken()
        {
            _clientId = HttpContextAccessor.HttpContext.Request.Headers["ClientId"];
            _clientName = HttpContextAccessor.HttpContext.Request.Headers["ClientName"];
            _refreshToken = HttpContextAccessor.HttpContext.Request.Headers["RefreshToken"];
            
            if (!Control(_clientId, _clientName, _refreshToken))
                return null;

            var newRefreshToken = _refreshTokenService.GetByRefreshToken(_refreshToken).Data;
            if (newRefreshToken != null && newRefreshToken?.ClientName == _clientName &&
                newRefreshToken?.ClientId == _clientId)
            {
                CreateDifferentRefreshToken(newRefreshToken);
                _refreshTokenService.Update(newRefreshToken);
                return newRefreshToken;
            }

            return null;
        }

        public bool Control(params string[] args)
        {
            foreach (string arg in args)
            {
                if (arg == null || arg == "" || arg == "null")
                    return false;
            }

            return true;
        }
    }
}
