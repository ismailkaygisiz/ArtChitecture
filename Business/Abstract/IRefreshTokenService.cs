using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IRefreshTokenService : IServiceRepository<RefreshToken>
    {
        IDataResult<RefreshToken> GetByRefreshToken(string refreshToken);
        IDataResult<RefreshToken> GetByClientId(string clientId);
    }
}