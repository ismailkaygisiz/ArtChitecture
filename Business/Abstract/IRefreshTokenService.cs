using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRefreshTokenService : IServiceRepository<RefreshToken, int>
    {
        IDataResult<RefreshToken> GetByRefreshToken(string refreshToken);
        IDataResult<RefreshToken> GetByRefreshTokenAndClientIdAndClientName(string refreshToken, string clientId, string clientName);
        IDataResult<RefreshToken> GetByClientId(string clientId);
        IDataResult<List<RefreshToken>> GetByUserId(int userId);
    }
}