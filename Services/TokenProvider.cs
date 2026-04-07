using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoldenMind.Services
{
    public class TokenProvider
    {
        public static JwtSecurityToken GenerateSecurityToken(List<Claim> claims)
        {
            // SignCredentials
            SymmetricSecurityKey key = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes("asfasfas"));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // Generete JwtSecurityToken 
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "https://localhost:7080/",
                audience: "https://localhost:7080/",
                claims: null,
                expires: DateTime.Now.AddHours(2),
                signingCredentials : signingCredentials
                );
            
            return jwtSecurityToken;
        }
    }
}
