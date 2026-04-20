using GoldenMind.Dto;
using GoldenMind.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoldenMind.Controllers
{
    [ApiController]
    [Route("/api/alarms")]
    public class ALarmController : ControllerBase
    {
        private readonly AppDBContext _context;
        public ALarmController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAllAlarms()
        {
            var alarms = await _context.alarms.ToListAsync();
            List<AlarmDto> alarmsDto = new List<AlarmDto>();
            foreach(var item in alarms)
            {
                var alarmDto = new AlarmDto();
                alarmDto.DateTime = item.DateTime;
                alarmDto.UserId = item.UserId;
                alarmDto.Repeat = item.Repeat;
                alarmDto.Discard = item.Discard;
                alarmsDto.Add(alarmDto);
            }
            return Ok(new
            {
                data = alarmsDto,
                msg = "Success"
            });
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSingleAlarm(int Id)
        {
            var alram = await _context.alarms.FindAsync(Id);
            if(alram != null)
                return Ok(alram);
            return NoContent(); 
        }
        [HttpPost]
        public async Task<IActionResult> CreateAlarm([FromBody] AlarmDto alarmDto)
        {
            var patient = await _context.patiens.FindAsync(alarmDto.UserId);

            if(patient != null)
            {
                var newAlarm = new Alarms();
                newAlarm.Patient = patient;
                newAlarm.UserId = alarmDto.UserId;
                newAlarm.Repeat = alarmDto.Repeat;
                newAlarm.Discard = alarmDto.Discard;
                newAlarm.DateTime = alarmDto.DateTime;
                await _context.alarms.AddAsync(newAlarm);
                return NoContent();
            }
            return BadRequest("InValid data");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]AlarmDto alarmsDto)
        {
            var patient = await _context.patiens.FindAsync(alarmsDto.UserId);


            return NoContent();
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> Delete(int Id)
        {
            var alarm = await _context.alarms.FindAsync(Id);
            if(alarm != null)
            {
                _context.alarms.Remove(alarm);
                await _context.SaveChangesAsync();
                return NoContent();
            }

            return NotFound("alarm does not exist");
        }
    }
}
