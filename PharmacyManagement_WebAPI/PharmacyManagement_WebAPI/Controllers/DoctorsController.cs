using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyManagement_WebAPI.Models;
using PharmacyManagement_WebAPI.Repository;

namespace PharmacyManagement_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorsController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorRepository.GetAllDoctors();
            return Ok(doctors);
        }
        [HttpGet("{DocName}")]
        public async Task<IActionResult> GetDoctor([FromRoute] string DocName)
        {
            var doctor = await _doctorRepository.GetDoctorByName(DocName);
            return Ok(doctor);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddDoctor([FromBody] Doctor doctor)
        {
            var id = await _doctorRepository.AddDoctor(doctor);
            return CreatedAtAction(nameof(AddDoctor), id);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int id)
        {
            await _doctorRepository.DeleteDoctor(id);
            return Ok();
        }
    }
}
