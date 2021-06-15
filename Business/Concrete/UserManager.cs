using System.Collections.Generic;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(User entity)
        {
            var entityToDelete = GetById(entity.Id).Data;

            _userDal.Delete(entityToDelete);
            return new SuccessResult();
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult();
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<List<User>> GetByFirstName(string firstName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.FirstName == firstName));
        }

        public IDataResult<List<User>> GetByLastName(string lastName)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.LastName == lastName));
        }

        public IDataResult<List<User>> GetByStatus(bool status)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Status == status));
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<UserOperationClaimDetailDto> GetUserOperationClaims(int userId)
        {
            return new SuccessDataResult<UserOperationClaimDetailDto>(_userDal.GetUserOperationClaimsDetails(userId));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
    }
}