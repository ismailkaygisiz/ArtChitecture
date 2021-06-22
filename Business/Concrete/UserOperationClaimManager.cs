using System.Collections.Generic;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private IUserOperationClaimDal _userOperationClaimDal;
        private IRequestUserService _requestUserService;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal,
            IRequestUserService requestUserService)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _requestUserService = requestUserService;
        }

        [TransactionScopeAspect]
        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public IResult Add(UserOperationClaim entity)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _userOperationClaimDal.Add(entity);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [SecuredOperation("Admin")]
        public IResult Delete(UserOperationClaim entity)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            var entityToDelete = GetById(entity.Id).Data;

            _userOperationClaimDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public IResult Update(UserOperationClaim entity)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _userOperationClaimDal.Update(entity);
            return new SuccessResult();
        }

        [SecuredOperation("Admin")]
        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(u => u.Id == id));
        }

        [SecuredOperation("Admin")]
        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }

        [SecuredOperation("Admin")]
        public IDataResult<List<UserOperationClaim>> GetByClaimId(int claimId)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(
                _userOperationClaimDal.GetAll(u => u.OperationClaimId == claimId));
        }

        public IDataResult<List<UserOperationClaim>> GetByUserId(int userId)
        {
            IResult result = BusinessRules.Run(_requestUserService.CheckIfRequestUserIsNotEqualsUser(userId));

            if (result != null)
            {
                return new ErrorDataResult<List<UserOperationClaim>>(result.Message);
            }

            return new SuccessDataResult<List<UserOperationClaim>>(
                _userOperationClaimDal.GetAll(u => u.UserId == userId));
        }
    }
}
