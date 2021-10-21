using System.Collections.Generic;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IUserOperationClaimService : IServiceRepository<UserOperationClaim, int>
    {
        IResult AddForSuperUser(UserOperationClaim entity);
        IDataResult<List<UserOperationClaim>> GetByClaimId(int claimId);
        IDataResult<List<UserOperationClaim>> GetByUserId(int userId);
    }
}