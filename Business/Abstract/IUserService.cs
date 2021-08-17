using System.Collections.Generic;
using Core.Business;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IUserService : IServiceRepository<User>
    {
        IResult UpdateForAuth(User entity);
        IDataResult<User> AddWithId(User entity);
        IDataResult<List<User>> GetByFirstName(string firstName);
        IDataResult<List<User>> GetByLastName(string lastName);
        IDataResult<List<User>> GetByStatus(bool status);
        IDataResult<User> GetByEmail(string email);
        IDataResult<User> GetByEmailForAuth(string email);
        IDataResult<User> GetByIdForAuth(int id);
        IDataResult<UserOperationClaimDetailDto> GetUserOperationClaims(int userId);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}