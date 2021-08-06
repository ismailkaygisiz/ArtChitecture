using Business.Abstract;
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
using Microsoft.Extensions.Configuration;
using System;

namespace Business.Concrete
{
    public class AuthManager : BusinessService, IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserService _userService;
        public bool UseRefreshTokenEndDate { get; set; }

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var roles = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, roles);

            while (_userService.GetByRefreshToken(accessToken.RefreshToken).Data != null)
            {
                accessToken.RefreshToken = _tokenHelper.CreateRefreshToken();
            }

            user.RefreshToken = accessToken.RefreshToken;

            if (UseRefreshTokenEndDate)
                user.RefreshTokenEndDate = DateTime.Now.AddMinutes(Configuration.GetSection("TokenOptions").Get<TokenOptions>().RefreshTokenExpiration);
            else
                user.RefreshTokenEndDate = null;

            _userService.UpdateForAuth(user);
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

            if (result != null) return new ErrorDataResult<AccessToken>(result.Message);

            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);

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
            return new SuccessDataResult<AccessToken>(CreateAccessToken(user).Data,
                BusinessMessages.PasswordChanged());
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(LoginValidator))]
        public IDataResult<AccessToken> Login(UserForLoginDto userForLoginDto)
        {
            var result = BusinessRules.Run(
                CheckIfUserIsNotExists(userForLoginDto)
            );

            if (result != null) return new ErrorDataResult<AccessToken>(result.Message);

            var user = _userService.GetByEmailForAuth(userForLoginDto.Email).Data;
            return new SuccessDataResult<AccessToken>(CreateAccessToken(user).Data,
                BusinessMessages.SuccessfulLogin());
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(RegisterValidator))]
        public IDataResult<AccessToken> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            var result = BusinessRules.Run(
                CheckIfUserIsAlreadyExists(userForRegisterDto.Email)
            );

            if (result != null) return new ErrorDataResult<AccessToken>(result.Message);

            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

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
            return new SuccessDataResult<AccessToken>(CreateAccessToken(user).Data,
                BusinessMessages.SuccessfulRegister());
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
            if (user == null) return new ErrorResult(BusinessMessages.UserIsNotExists());

            if (user != null)
                if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
                    return new ErrorResult(BusinessMessages.PasswordIsNotTrue());

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