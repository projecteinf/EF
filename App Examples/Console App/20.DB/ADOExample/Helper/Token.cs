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
            byte[] keyBytes = xifratge.GetKey();

            if (keyBytes == null || keyBytes.Length < 32) 
                throw new InvalidOperationException("La clau de xifratge no és vàlida.");
            
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(xifratge.GetKey());
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Uuid.ToString()),   
                new Claim(JwtRegisteredClaimNames.Email, user.Email),         
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Unique identifier del token
                new Claim("role", "Usuari") 
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "Bosc de la Coma",
                audience: "Bosc de la Coma",
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}