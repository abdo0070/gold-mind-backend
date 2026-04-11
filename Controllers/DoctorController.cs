using GoldenMind.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GoldenMind.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorController : ControllerBase
    {
        private AppDBContext _context;
        public DoctorController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> DoctorUsers()
        {
            var doctors = _context.careGavers.ToList();

            List<CareGaver> data = new List<CareGaver>();
            var res = new
            {
                doctors,
            };
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CareGaver doctor)
        {
            await _context.careGavers.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetById", new { id = doctor.Id }, doctor);
        }
        [HttpGet]
        [Route("patients/{id:int}")]
        public async Task<IActionResult> GetDoctorPatient([FromRoute] int id)
        {
            var patients = await _context.patiens.Where(u => u.CareGaverId == id).ToListAsync();
            return Ok(patients);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var doctor = _context.patiens.Where(d => d.Id == id)
                .Include(d => d.CareGaverId);
            return Ok(doctor);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var doctor = await _context.patiens.FindAsync(id);
            if (doctor != null)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CareGaver newDoctor)
        {
            return Ok();
        }

    }
}
