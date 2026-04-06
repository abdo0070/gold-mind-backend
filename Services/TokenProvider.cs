using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoldenMind.Services
{
    public class TokenProvider
    {
        public static string GenerateToken(List<Claim> claims)
        {
            // SignCredentials
            SymmetricSecurityKey key = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes("asfasfas"));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // Generete JwtSecurityToken 
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials : signingCredentials
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
