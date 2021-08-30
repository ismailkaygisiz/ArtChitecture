using Business.Abstract;
using Business.Helpers;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;

namespace Business.Concrete
{
    public class AuthManager : BusinessService, IAuthService
    {
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IRefreshTokenHelper _refreshTokenHelper;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserService _userService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IRefreshTokenService refreshTokenService, IRefreshTokenHelper refreshTokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _refreshTokenService = refreshTokenService;
            _refreshTokenHelper = refreshTokenHelper;
        }

        public bool UseRefreshTokenEndDate { get; set; }

        [TransactionScopeAspect]
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var roles = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, roles);

            UseRefreshTokenEndDate = _refreshTokenHelper.UseRefreshTokenEndDate;

            string refreshToken = HttpContextAccessor.HttpContext.Request.Headers["RefreshToken"];
            if (_refreshTokenHelper.Control(refreshToken))
                accessToken.RefreshToken = _refreshTokenHelper.UpdateOldRefreshToken();
            else
                accessToken.RefreshToken = _refreshTokenHelper.CreateNewRefreshToken(user);

            if (accessToken.RefreshToken == null)
                return new ErrorDataResult<AccessToken>();

            return new SuccessDataResult<AccessToken>(accessToken);
        }

        [TransactionScopeAspect]
        [SecuredOperation("User", "userForLoginDto.Email")]
        [ValidationAspect(typeof(LoginValidator))] // Will be Upgrade
        public IDataResult<AccessToken> ChangePassword(UserForLoginDto userForLoginDto, string newPassword) // New Model Will be Added for ChangePassword
        {
            var result = BusinessRules.Run(
                CheckIfUserIsNotExists(userForLoginDto),
                CheckIfNewPasswordIsEqualsOldPassword(userForLoginDto, newPassword));

            if (!result.Success)
                return new ErrorDataResult<AccessToken>(result.Message);

            HashingHelper.CreatePasswordHash(newPassword, out var passwordHash, out var passwordSalt);
            var oldUser = _userService.GetByEmailForAuth(userForLoginDto.Email).Data;

            var user = new User
            {
                Id = oldUser.Id,
                Email = oldUser.Email,
                FirstName = oldUser.FirstName,
                LastName = oldUser.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Update(user);
            return new SuccessDataResult<AccessToken>(CreateAccessToken(user).Data, BusinessMessages.PasswordChanged());
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(LoginValidator))]
        public IDataResult<AccessToken> Login(UserForLoginDto userForLoginDto)
        {
            var result = BusinessRules.Run(
                CheckIfUserIsNotExists(userForLoginDto)
            );

            if (!result.Success)
                return new ErrorDataResult<AccessToken>(result.Message);

            var user = _userService.GetByEmailForAuth(userForLoginDto.Email).Data;
            return new SuccessDataResult<AccessToken>(CreateAccessToken(user).Data, BusinessMessages.SuccessfulLogin());
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(RegisterValidator))]
        public IDataResult<AccessToken> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            var result = BusinessRules.Run(
                CheckIfUserIsAlreadyExists(userForRegisterDto.Email)
            );

            if (!result.Success)
                return new ErrorDataResult<AccessToken>(result.Message);

            HashingHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);
            return new SuccessDataResult<AccessToken>(CreateAccessToken(user).Data, BusinessMessages.SuccessfulRegister());
        }

        private IResult CheckIfUserIsAlreadyExists(string email)
        {
            if (_userService.GetByEmailForAuth(email).Data != null)
                return new ErrorResult(BusinessMessages.UserIsAlreadyExists());

            return new SuccessResult();
        }

        private IResult CheckIfUserIsNotExists(UserForLoginDto userForLoginDto)
        {
            var user = _userService.GetByEmailForAuth(userForLoginDto.Email).Data;
            if (user == null)
            {
                MsSqlLogger.Warn("Hatalı Giriş Denemesi Yapıldı");
                return new ErrorResult(BusinessMessages.UserIsNotExists());
            }

            if (user != null)
            {
                if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                {
                    MsSqlLogger.Warn("Hatalı Giriş Denemesi Yapıldı");
                    return new ErrorResult(BusinessMessages.PasswordIsNotTrue());
                }
            }

            return new SuccessResult();
        }

        private IResult CheckIfNewPasswordIsEqualsOldPassword(UserForLoginDto userForLoginDto, string newPassword)
        {
            if (userForLoginDto.Password == newPassword)
                return new ErrorResult(BusinessMessages.NewPasswordCannotBeTheSameAsTheOldPassword());

            return new SuccessResult();
        }
    }
}