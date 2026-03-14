using GoldenMind.Models;
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
            List<DoctorModel> data = new List<DoctorModel>();
            var res = new
            {
                doctors = data,
                msg = "SUCCESS"
            };
            return Ok(res);
        }
    }
}
