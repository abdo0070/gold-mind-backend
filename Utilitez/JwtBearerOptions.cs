using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace GoldenMind.Auth
{
    public class JwtBearerOptions
    {
        public String Audiene { get; set; }
        public String Authority { get; set; }
        public DateTime expiry { get; set; }
        public List<Claim> claims { get; set; }
        public SigningCredentials signingCredentials { set; get; }
    }
}
