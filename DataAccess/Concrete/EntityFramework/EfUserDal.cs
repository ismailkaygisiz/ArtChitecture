using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ProjectDbContext>, IUserDal
    {
        public UserOperationClaimDetailDto GetUserOperationClaimsDetails(int userId)
        {
            using (var context = new ProjectDbContext())
            {
                var result = from user in context.Users
                             where user.Id == userId
                             select new UserOperationClaimDetailDto
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 Claims = (from userOperationClaim in context.UserOperationClaims
                                           join operationClaim in context.OperationClaims on userOperationClaim.OperationClaimId equals
                                               operationClaim.Id
                                           where userOperationClaim.Id == userId
                                           select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name }).ToList()
                             };

                return result.SingleOrDefault();
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ProjectDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select operationClaim;

                return result.ToList();
            }
        }
    }
}