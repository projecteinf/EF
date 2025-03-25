/// 
/// dotnet add package Microsoft.IdentityModel.Tokens
/// dotnet add package System.IdentityModel.Tokens.Jwt
/// 

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using BoscComa.Xifratge;
using BoscComa.Helper;

namespace BoscComa.ADO
{
    static class Token
    {
        public static string AccessToken { get; set; }
        public static string RefreshToken { get; set; }

        // Aplicació de SOLID
        public static ITokenResponse GenerateJwtToken(User user,ITokenResponse tokenResponse)
        {
            DadesXifratgeAES xifratge = DadesXifratgeAES.XifratgeAES;
            byte[] keyBytes = xifratge.GetKey();

            if (keyBytes == null || keyBytes.Length < 32) 
                throw new InvalidOperationException("La clau de xifratge no és vàlida.");   // Millorar amb error personalitzat
            
            // Backend genera i valida tokens => podem utilitzar clau simètrica.
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
                expires: DateTime.UtcNow.AddMinutes(30),    // UtcNow considera els fusos horaris
                signingCredentials: signingCredentials
            );

            tokenResponse.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            tokenResponse.RefreshToken = RandomGenerator.GenerateSecureToken(64); // Token => Cadena aleatòria llarga
            
            tokenResponse.Save();
            return tokenResponse;
        }
    }
}