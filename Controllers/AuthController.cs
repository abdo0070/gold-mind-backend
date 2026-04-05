using GoldenMind.Dto;
using GoldenMind.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Text;

namespace GoldenMind.Controllers
{
    [Route("api/caregaver/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AppDBContext _context;
        private readonly UserManager<User> _userManager;
        public AuthController(AppDBContext context,UserManager<User> userManager)
        {
            _userManager= userManager;
            _context = context;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if(ModelState.IsValid)
            {
                user.Doctor = null;
                IdentityResult result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                    return Ok("Created");
                
                foreach(var i in result.Errors)
                {
                    ModelState.AddModelError(i.Description,i.Description);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserDto authData)
        {
            // get the user from the DB
            User userDB = await _context.users.Include(u => u.Email == authData.Email).FirstOrDefaultAsync();
            if(userDB != null)
            {
            // generate token 
            List<Claim> userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.Email,userDB.Email));
                userClaims.Add(new Claim(ClaimTypes.NameIdentifier, userDB.Id.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Name, userDB.Name));
                var TokenClaim = new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString());

                // sign Credintails
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdfasfsafa"));
                SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                userClaims.Add(TokenClaim);
            JwtSecurityToken jWtSecurityToken = new JwtSecurityToken(
                issuer: "",
                audience: "",
                expires: DateTime.Now.AddHours(1),
                claims : userClaims,
                signingCredentials : signingCredentials
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(jWtSecurityToken),
                expiry = jWtSecurityToken.ValidTo
            });
            }
            return BadRequest();
        }
    }
   

}
