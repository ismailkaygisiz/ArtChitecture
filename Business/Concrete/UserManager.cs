using System.Collections.Generic;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IRequestUserService _requestUserService;

        public UserManager(IUserDal userDal, IRequestUserService requestUserService)
        {
            _userDal = userDal;
            _requestUserService = requestUserService;
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User entity)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _userDal.Add(entity);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult Delete(User entity)
        {
            IResult result = BusinessRules.Run(_requestUserService.CheckIfRequestUserIsNotEqualsUser(entity.Id));

            if (result != null)
            {
                return result;
            }

            var entityToDelete = GetById(entity.Id).Data;

            _userDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User entity)
        {
            IResult result = BusinessRules.Run(_requestUserService.CheckIfRequestUserIsNotEqualsUser(entity.Id));

            if (result != null)
            {
                return result;
            }

            _userDal.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<User> GetById(int id)
        {
            IResult result = BusinessRules.Run(_requestUserService.CheckIfRequestUserIsNotEqualsUser(id));

            if (result != null)
            {
                return new ErrorDataResult<User>(result.Message);
            }

            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        [SecuredOperation("Admin")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        [SecuredOperation("Admin")]
        public IDataResult<List<User>> GetByFirstName(string firstName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.FirstName == firstName));
        }

        [SecuredOperation("Admin")]
        public IDataResult<List<User>> GetByLastName(string lastName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.LastName == lastName));
        }

        [SecuredOperation("Admin")]
        public IDataResult<List<User>> GetByStatus(bool status)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Status == status));
        }

        public IDataResult<User> GetByEmail(string email)
        {
            IResult result = BusinessRules.Run(_requestUserService.CheckIfRequestUserIsNotEqualsUser(email));

            if (result != null)
            {
                return new ErrorDataResult<User>(result.Message);
            }

            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        [SecuredOperation("Admin")]
        public IDataResult<UserOperationClaimDetailDto> GetUserOperationClaims(int userId)
        {
            return new SuccessDataResult<UserOperationClaimDetailDto>(_userDal.GetUserOperationClaimsDetails(userId));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            IResult result = BusinessRules.Run(_requestUserService.CheckIfRequestUserIsNotEqualsUser(user.Id));

            if (result != null)
            {
                return new ErrorDataResult<List<OperationClaim>>(result.Message);
            }

            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
    }
}
