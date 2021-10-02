using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EducationalCenter.BLL.Interfaces
{
    public interface IJwtHandlerService
    {
        SigningCredentials GetSigningCredentials();

        List<Claim> GetClaims(IdentityUser user);

        JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims);
    }
}
