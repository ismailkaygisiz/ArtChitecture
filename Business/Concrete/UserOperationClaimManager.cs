using System.Collections.Generic;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim entity)
        {
            _userOperationClaimDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(UserOperationClaim entity)
        {
            var entityToDelete = GetById(entity.Id).Data;

            _userOperationClaimDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IResult Update(UserOperationClaim entity)
        {
            _userOperationClaimDal.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(u => u.Id == id));
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }

        public IDataResult<List<UserOperationClaim>> GetByClaimId(int claimId)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(
                _userOperationClaimDal.GetAll(u => u.OperationClaimId == claimId));
        }

        public IDataResult<List<UserOperationClaim>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(
                _userOperationClaimDal.GetAll(u => u.UserId == userId));
        }
    }
}