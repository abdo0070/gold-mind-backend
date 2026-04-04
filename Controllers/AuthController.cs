using GoldenMind.Dto;
using GoldenMind.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace GoldenMind.Controllers
{
    [Route("api/caregaver/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AppDBContext _context;
        public AuthController(AppDBContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if(ModelState.IsValid)
            {
                user.Doctor = null;
                await _context.users.AddAsync(user);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody]UserDto authData)
        {
            return Ok();
        }
    }
   

}
