using Core.Business;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService : IServiceRepository<User, int>
    {
        IResult UpdateForAuth(User entity);
        IDataResult<User> AddWithId(User entity);
        IDataResult<List<User>> GetByStatus(bool status);
        IDataResult<User> GetByEmail(string email);
        IDataResult<User> GetByEmailForAuth(string email);
        IDataResult<User> GetByIdForAuth(int id);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}