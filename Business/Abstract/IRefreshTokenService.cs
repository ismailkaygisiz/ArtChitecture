using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRefreshTokenService : IServiceRepository<RefreshToken>
    {
        IDataResult<RefreshToken> GetByRefreshToken(string refreshToken);
        IDataResult<RefreshToken> GetByClientNameAndUserId(string clientName, int userId);
        IDataResult<RefreshToken> GetByClientId(string clientId);
    }
}
