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
using System;
using System.Linq;

namespace Business.Concrete
{
    public class AuthManager : BusinessService, IAuthService
    {
        private readonly IRefreshTokenHelper _refreshTokenHelper;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IUserService _userService;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public AuthManager(IUserService userService, IRefreshTokenHelper refreshTokenHelper, IUserOperationClaimService userOperationClaimService, IRefreshTokenService refreshTokenService)
        {
            _userService = userService;
            _refreshTokenHelper = refreshTokenHelper;
            _refreshTokenService = refreshTokenService;
            _userOperationClaimService = userOperationClaimService;
        }

        public bool UseRefreshTokenEndDate { get; set; }

        [TransactionScopeAspect]
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var roles = _userService.GetClaims(user).Data;
            var accessToken = UserTokenHelper.CreateToken(user, roles);

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

        public IDataResult<AccessToken> RefreshToken()
        {
            string refreshToken = HttpContextAccessor.HttpContext.Request.Headers["RefreshToken"];

            var newRefreshToken = _refreshTokenService.GetByRefreshToken(refreshToken).Data;
            if (newRefreshToken != null)
            {
                var user = _userService.GetByIdForAuth(newRefreshToken.UserId).Data;
                if (UseRefreshTokenEndDate)
                {
                    if (newRefreshToken.RefreshTokenEndDate > DateTime.Now)
                        return RefreshTokenControl(user);

                    RequestUserService.SetRequestUser(null);
                    return new ErrorDataResult<AccessToken>();
                }

                return RefreshTokenControl(user);
            }

            RequestUserService.SetRequestUser(null);
            return new ErrorDataResult<AccessToken>();
        }

        [TransactionScopeAspect]
        [LoginRequired]
        [SecuredOperation("", "userForLoginDto.Email")]
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
                UserId = oldUser.UserId,
                Email = oldUser.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Update(user);

            string refreshToken = HttpContextAccessor.HttpContext.Request.Headers["RefreshToken"];
            string clientId = HttpContextAccessor.HttpContext.Request.Headers["ClientId"];
            string clientName = HttpContextAccessor.HttpContext.Request.Headers["ClientName"];

            _refreshTokenService.GetByUserId(user.UserId).Data
                .Where(r => r.ClientId != clientId || r.ClientName != clientName || r.RefreshTokenValue != refreshToken)
                .ToList().ForEach(token =>
                    _refreshTokenService.Delete(new DeleteModel()
                    {
                        ID = token.RefreshTokenId
                    })
                );

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
        public IDataResult<AccessToken> Register(UserForRegisterDto userForRegisterDto)
        {
            var result = BusinessRules.Run(
                CheckIfUserIsAlreadyExists(userForRegisterDto.Email)
            );

            if (!result.Success)
                return new ErrorDataResult<AccessToken>(result.Message);

            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out var passwordHash, out var passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);

            _userOperationClaimService.AddForSuperUser(new UserOperationClaim()
            {
                UserId = user.UserId,
                OperationClaimId = 2
            });

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
                return new ErrorResult(BusinessMessages.UserIsNotExists());

            if (user != null)
            {
                if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                    return new ErrorResult(BusinessMessages.PasswordIsNotTrue());
            }

            return new SuccessResult();
        }

        private IResult CheckIfNewPasswordIsEqualsOldPassword(UserForLoginDto userForLoginDto, string newPassword)
        {
            if (userForLoginDto.Password == newPassword)
                return new ErrorResult(BusinessMessages.NewPasswordCannotBeTheSameAsTheOldPassword());

            return new SuccessResult();
        }

        private IDataResult<AccessToken> RefreshTokenControl(User user)
        {
            var result = CreateAccessToken(user);
            if (result.Success) return result;

            RequestUserService.SetRequestUser(null);
            return result;
        }
    }
}