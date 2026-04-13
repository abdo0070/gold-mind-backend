using GoldenMind.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GoldenMind.Controllers
{
    [ApiController]
    [Route("/api/alarms")]
    public class ALarmController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAlarms()
        {
            return Ok();
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
