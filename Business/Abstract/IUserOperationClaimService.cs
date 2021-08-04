using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserOperationClaimService : IServiceRepository<UserOperationClaim>
    {
        IResult AddForSuperUser(UserOperationClaim entity);
        IDataResult<List<UserOperationClaim>> GetByClaimId(int claimId);
        IDataResult<List<UserOperationClaim>> GetByUserId(int userId);
    }
}