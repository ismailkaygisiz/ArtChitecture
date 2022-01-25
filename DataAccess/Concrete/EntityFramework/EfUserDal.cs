using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ProjectDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ProjectDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.UserId
                    select operationClaim;

                return result.ToList();
            }
        }
    }
}