using GoldenMind.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GoldenMind.Controllers
{
    [Route("api/caregaver/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody]UserDto authData)
        {

            return Ok(authData);
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserDto authData)
        {
            return Ok();
        }
    }
   

}
