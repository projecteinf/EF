/// 
/// dotnet add package Microsoft.IdentityModel.Tokens
/// dotnet add package System.IdentityModel.Tokens.Jwt
/// 

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BoscComa.Xifratge;

namespace BoscComa.ADO
{
    static class Token
    {
        static public string GenerateJwtToken(User user)
        {
            DadesXifratgeAES xifratge = DadesXifratgeAES.XifratgeAES;
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(xifratge.GetKey());
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}