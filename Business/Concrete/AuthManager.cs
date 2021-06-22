﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
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
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IRequestUserService _requestUserService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IRequestUserService requestUserService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _requestUserService = requestUserService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var roles = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, roles);

            return new SuccessDataResult<AccessToken>(accessToken);
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(LoginValidator))]
        public IDataResult<AccessToken> ChangePassword(UserForLoginDto userForLoginDto, string newPassword)
        {
            IResult result = BusinessRules.Run(
                _requestUserService.CheckIfRequestUserIsNotEqualsUser(userForLoginDto.Email),
                CheckIfUserPasswordIsNotTrue(userForLoginDto.Email, userForLoginDto.Password),
                CheckIfNewPasswordIsEqualsOldPassword(userForLoginDto, newPassword));

            if (result != null)
            {
                return new ErrorDataResult<AccessToken>(result.Message);
            }

            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);

            var oldUser = _userService.GetByEmail(userForLoginDto.Email).Data;

            User user = new User
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
            return new SuccessDataResult<AccessToken>(CreateAccessToken(user).Data, Messages.PasswordChanged);
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(LoginValidator))]
        public IDataResult<AccessToken> Login(UserForLoginDto userForLoginDto)
        {
            IResult result = BusinessRules.Run(
                CheckIfUserIsNotExists(userForLoginDto.Email),
                CheckIfUserPasswordIsNotTrue(userForLoginDto.Email, userForLoginDto.Password)
            );

            if (result != null)
            {
                return new ErrorDataResult<AccessToken>(result.Message);
            }

            User user = _userService.GetByEmail(userForLoginDto.Email).Data;
            return new SuccessDataResult<AccessToken>(CreateAccessToken(user).Data, Messages.SuccessfulLogin);
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(RegisterValidator))]
        public IDataResult<AccessToken> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            IResult result = BusinessRules.Run(
                CheckIfUserIsAlreadyExists(userForRegisterDto.Email)
            );

            if (result != null)
            {
                return new ErrorDataResult<AccessToken>(result.Message);
            }

            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            User user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);
            return new SuccessDataResult<AccessToken>(CreateAccessToken(user).Data, Messages.SuccessfulRegister);
        }

        private IResult CheckIfUserIsAlreadyExists(string email)
        {
            if (_userService.GetByEmail(email).Data != null)
            {
                return new ErrorResult(Messages.UserIsAlreadyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfUserIsNotExists(string email)
        {
            var user = _userService.GetByEmail(email).Data;
            if (user == null)
            {
                return new ErrorResult(Messages.UserIsNotExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfUserPasswordIsNotTrue(string email, string password)
        {
            var user = _userService.GetByEmail(email).Data;
            if (user != null)
            {
                if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                {
                    return new ErrorResult(Messages.PasswordIsNotTrue);
                }
            }

            return new SuccessResult();
        }

        private IResult CheckIfNewPasswordIsEqualsOldPassword(UserForLoginDto userForLoginDto, string newPassword)
        {
            if (userForLoginDto.Password == newPassword)
            {
                return new ErrorResult(Messages.NewPasswordCannotBeTheSameAsTheOldPassword);
            }

            return new SuccessResult();
        }
    }
}
