using Business.Abstract;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class GroupOperationClaimManager : IGroupOperationClaimService
    {
        private readonly IGroupOperationClaimDal _groupOperationClaimDal;

        public GroupOperationClaimManager(IGroupOperationClaimDal groupOperationClaimDal)
        {
            _groupOperationClaimDal = groupOperationClaimDal;
        }

        public IResult Add(GroupOperationClaim entity)
        {
            var result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _groupOperationClaimDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(GroupOperationClaim entity)
        {
            var result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _groupOperationClaimDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<GroupOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<GroupOperationClaim>>(_groupOperationClaimDal.GetAll());
        }

        public IDataResult<GroupOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<GroupOperationClaim>(_groupOperationClaimDal.Get(g => g.Id == id));
        }

        public IResult Update(GroupOperationClaim entity)
        {
            var result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _groupOperationClaimDal.Update(entity);
            return new SuccessResult();
        }
    }
}
