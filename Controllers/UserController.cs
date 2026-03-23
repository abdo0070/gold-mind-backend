using GoldenMind.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace GoldenMind.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private AppDBContext _context;
        public UserController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _context.users.ToListAsync();
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> Create(User newUser)
        {
            var doctor = await _context.doctors.FindAsync(2);
            newUser.Doctor = doctor;

            _context.users.Add(newUser);

            await _context.SaveChangesAsync();

            return Ok(newUser);
        }
        [HttpGet()]
        [Route("{Id}")]
        public async Task<IActionResult> GetSingleUser(int Id)
        {
            var user = await _context.users.FindAsync(Id);
            return Ok(new
            {
                data = user,
                Msg = "SUCCESS",
                STATUS_CODE = 200
            });
        }
        [HttpPut]
        public async Task<IActionResult> Update(User reqUser)
        {
            return NoContent();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user != null)
            {
                _context.users.Remove(user);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound("The User Does Not Exist");
        }

    }
}
