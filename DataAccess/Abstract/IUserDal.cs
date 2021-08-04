﻿using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        UserOperationClaimDetailDto GetUserOperationClaimsDetails(int userId);
        List<OperationClaim> GetClaims(User user);
    }
}