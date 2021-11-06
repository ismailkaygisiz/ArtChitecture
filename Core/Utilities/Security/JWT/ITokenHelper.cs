using Core.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper<T>
    {
        AccessToken CreateToken(T user, List<OperationClaim> operationClaims);
        JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, T user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims);
        IEnumerable<Claim> SetClaims(T user, List<OperationClaim> operationClaims);

    }
}