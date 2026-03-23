using GoldenMind.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace GoldenMind.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorContoller : ControllerBase
    {
        private AppDBContext _context;
        public DoctorContoller(AppDBContext context) 
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
                msg = "SUCCESS"
            };
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DoctorModel doctor)
        {
            await _context.doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDoctorPatient(int id)
        {
            var patients = await _context.users.Where(u => u.DoctorId == id).ToListAsync();
            return Ok(patients);
        }
    }
}
