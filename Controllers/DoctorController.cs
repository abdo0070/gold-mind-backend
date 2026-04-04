using GoldenMind.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
            var doctors = _context.doctors.ToList();

            List<DoctorModel> data = new List<DoctorModel>();
            var res = new
            {
                doctors,
            };
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DoctorModel doctor)
        {
            await _context.doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetById", new {id = doctor.Id},doctor);
        }
        [HttpGet]
        [Route("patients/{id:int}")]
        public async Task<IActionResult> GetDoctorPatient([FromRoute]int id)
        {
            var patients = await _context.users.Where(u => u.DoctorId == id).ToListAsync();
            return Ok(patients);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var doctor = _context.doctors.Where(d => d.Id == id)
                .Include(d => d.patients);
            return Ok(doctor);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var doctor = await _context.doctors.FindAsync(id);
            if(doctor != null)
            {
                _context.doctors.Remove(doctor);
                //_context.Entry(doctor).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult>Update(DoctorModel newDoctor)
        {
            return Ok();
        }
    }
}
