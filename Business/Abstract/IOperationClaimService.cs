using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IOperationClaimService : IServiceRepository<OperationClaim>
    {
        IDataResult<OperationClaim> GetByName(string operationClaimName);
    }
}