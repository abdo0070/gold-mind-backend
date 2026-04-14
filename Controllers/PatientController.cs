using GoldenMind.Dto;
using GoldenMind.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace GoldenMind.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientController : ControllerBase
    {
        private AppDBContext _context;
        public PatientController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var patients = await _context.patiens.ToListAsync();
            return Ok(new
            {
               patients,
                Msg = "Success"
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {

            var careGaver = await _context.careGavers.FindAsync(patient.CareGaverId);
            patient.careGaver = careGaver;
            if(careGaver != null)
            {
                _context.patiens.Add(patient);
                await _context.SaveChangesAsync();
                return Ok(patient);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetSingleUser(int Id)
        {
            var patient = await _context.patiens.FindAsync(Id);
            PatientDto patientDto = new PatientDto();
            patientDto.Id = patient.Id;
            patientDto.CareGaverId = patient.CareGaverId;
            patientDto.Name = patient.Name;
            return Ok(new
            {
                data = patientDto,
                Msg = "SUCCESS",
            });
        }
        [HttpPut]
        public async Task<IActionResult> Update(PatientDto user)
        {
            return NoContent();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _context.patiens.FindAsync(id);
            if (patient != null)
            {
                _context.patiens.Remove(patient);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound("The Patient Does Not Exist");
        }

    }
}
