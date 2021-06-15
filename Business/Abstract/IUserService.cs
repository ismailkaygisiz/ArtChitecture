using System.Collections.Generic;
using Core.Business;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IUserService : IServiceRepository<User>
    {
        IDataResult<List<User>> GetByFirstName(string firstName);
        IDataResult<List<User>> GetByLastName(string lastName);
        IDataResult<List<User>> GetByStatus(bool status);
        IDataResult<User> GetByEmail(string email);
        IDataResult<UserOperationClaimDetailDto> GetUserOperationClaims(int userId);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}