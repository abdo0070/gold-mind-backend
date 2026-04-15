using GoldenMind.Dto;
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
                msg = "Sucess"
            });
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSingleAlarm(int Id)
        {
            return Ok(Id);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAlarm([FromBody] AlarmDto alarmDto)
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]AlarmDto alarmsDto)
        {
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            return NoContent();
        }
    }
}
