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

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var roles = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, roles);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        [ValidationAspect(typeof(LoginValidator))]
        [TransactionScopeAspect]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            IResult result = BusinessRules.Run(
                CheckIfUserIsNotExists(userForLoginDto.Email),
                CheckIfUserPasswordIsNotTrue(userForLoginDto.Email, userForLoginDto.Password)
            );

            if (result != null)
            {
                return new ErrorDataResult<User>(result.Message);
            }

            var user = _userService.GetByEmail(userForLoginDto.Email);
            return new SuccessDataResult<User>(user.Data);
        }

        [TransactionScopeAspect]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            IResult result = BusinessRules.Run(
                CheckIfUserIsAlreadyExists(userForRegisterDto.Email)
            );

            if (result != null)
            {
                return new ErrorDataResult<User>(result.Message);
            }

            User user = CreateUser(userForRegisterDto, password).Data;
            _userService.Add(user);
            return new SuccessDataResult<User>(user);
        }

        private IResult CheckIfUserIsAlreadyExists(string email)
        {
            if (_userService.GetByEmail(email).Data != null)
            {
                return new ErrorResult("Kullanıcı zaten var");
            }

            return new SuccessResult();
        }

        private IResult CheckIfUserIsNotExists(string email)
        {
            var user = _userService.GetByEmail(email).Data;
            if (user == null)
            {
                return new ErrorResult("Kullanıcı Yok");
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
                    return new ErrorResult("Parola Hatalı");
                }
            }

            return new SuccessResult();
        }

        private IDataResult<User> CreateUser(UserForRegisterDto userForRegisterDto, string password)
        {
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

            return new SuccessDataResult<User>(user);
        }
    }
}
