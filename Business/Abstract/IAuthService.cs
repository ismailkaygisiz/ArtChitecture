using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;

namespace Business.Abstract
{
    public interface IAuthService
    {
        bool UseRefreshTokenEndDate { get; set; }
        IDataResult<AccessToken> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<AccessToken> Login(UserForLoginDto userForLoginDto);
        IDataResult<AccessToken> CreateAccessToken(User user,string refreshToken, string clientName, string clientId);
        IDataResult<AccessToken> ChangePassword(UserForLoginDto userForLoginDto, string newPassword);
    }
}