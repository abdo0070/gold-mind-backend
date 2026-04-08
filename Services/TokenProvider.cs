using GoldenMind.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoldenMind.Services
{
    public class TokenProvider
    {
        private readonly JwtOptions _jwtOptions;
        public TokenProvider(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }
        public JwtSecurityToken GenerateSecurityToken(List<Claim> claims)
        {
            // SignCredentials
            SymmetricSecurityKey key = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(_jwtOptions.Key));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // Generete JwtSecurityToken 
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: null,
                expires: DateTime.Now.AddHours(2),
                signingCredentials : signingCredentials
                );
            
            return jwtSecurityToken;
        }
    }
}
