using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var users = await _context.doctors.Include(doctor => doctor.patients).ToListAsync();
            return Ok(users);
        }
    }
}
