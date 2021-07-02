using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        [TransactionScopeAspect]
        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(UserOperationClaimValidator))]
        [CacheRemoveAspect("IUserOperationClaimService.Get")]
        public IResult Add(UserOperationClaim entity)
        {
            var result = BusinessRules.Run();

            if (result != null) return result;

            _userOperationClaimDal.Add(entity);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [SecuredOperation("Admin")]
        [CacheRemoveAspect("IUserOperationClaimService.Get")]
        public IResult Delete(UserOperationClaim entity)
        {
            var result = BusinessRules.Run();

            if (result != null) return result;

            var entityToDelete = GetById(entity.Id).Data;

            _userOperationClaimDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        [SecuredOperation("Admin")]
        [ValidationAspect(typeof(UserOperationClaimValidator))]
        [CacheRemoveAspect("IUserOperationClaimService.Get")]
        public IResult Update(UserOperationClaim entity)
        {
            var result = BusinessRules.Run();

            if (result != null) return result;

            _userOperationClaimDal.Update(entity);
            return new SuccessResult();
        }

        [SecuredOperation("Admin")]
        [CacheAspect]
        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(u => u.Id == id));
        }

        [SecuredOperation("Admin")]
        [CacheAspect]
        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }

        [SecuredOperation("Admin")]
        [CacheAspect]
        public IDataResult<List<UserOperationClaim>> GetByClaimId(int claimId)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(
                _userOperationClaimDal.GetAll(u => u.OperationClaimId == claimId));
        }

        [SecuredOperation("User", "userId")]
        [CacheAspect]
        public IDataResult<List<UserOperationClaim>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(
                _userOperationClaimDal.GetAll(u => u.UserId == userId));
        }
    }
}