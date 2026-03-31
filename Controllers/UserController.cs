using GoldenMind.Dto;
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
            List<UserDto> userDtos = new List<UserDto>();
            foreach(var user in users) // O(n)
            {
                UserDto newUserDto = new UserDto();
                newUserDto.Id = user.Id;
                newUserDto.DoctorId = user.DoctorId;
                newUserDto.Name = user.Name;
                newUserDto.Email = user.Email;
                userDtos.Add(newUserDto);
            }
            return Ok(new
            {
                Data = userDtos,
                Msg = "Success"
            });
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
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetSingleUser(int Id)
        {
            var user = await _context.users.FindAsync(Id);
            UserDto userDto = new UserDto();
            userDto.Id = user.Id;
            userDto.DoctorId = user.DoctorId;
            userDto.Name = user.Name;
            user.Password = user.Password;
            return Ok(new
            {
                data = userDto,
                Msg = "SUCCESS",
            });
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserDto user)
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
