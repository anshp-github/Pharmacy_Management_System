using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyManagement_WebAPI.Models;
using PharmacyManagement_WebAPI.Repository;
using PharmacyManagement_WebAPI.Services;

namespace PharmacyManagement_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class DoctorsController : ControllerBase
    {
        public readonly DoctorServices _doctorServices;
        public DoctorsController(DoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorServices.GetAllDoctors();
            return Ok(doctors);
        }
        [HttpGet("{DocName}")]
        public async Task<IActionResult> GetDoctor([FromRoute] string DocName)
        {
            var doctor = await _doctorServices.GetDoctorByName(DocName);
            return Ok(doctor);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorRegistration doctor)
        {
            var id = await _doctorServices.AddDoctor(doctor);
            return CreatedAtAction(nameof(AddDoctor), id);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int id)
        {
            await _doctorServices.DeleteDoctor(id);
            return Ok();
        }
    }
}
