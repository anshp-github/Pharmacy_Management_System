using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyManagement_WebAPI.Models;
using PharmacyManagement_WebAPI.Repository;
using PharmacyManagement_WebAPI.Services;

namespace PharmacyManagement_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        public readonly MedicineServices _medicineServices;
        public MedicinesController(MedicineServices medicineServices)
        {
            _medicineServices = medicineServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMedicines()
        {
            var medicines = await _medicineServices.GetAllMedicines();
            return Ok(medicines);
        }
        [HttpGet("{MedName}")]
        public async Task<IActionResult> GetMedicine([FromRoute] string MedName)
        {
            var medcine = await _medicineServices.GetMedicineByName(MedName);
            return Ok(medcine);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddMedicine([FromBody] Medicine medicine)
        {
            var id = await _medicineServices.AddMedicine(medicine);
            return CreatedAtAction(nameof(AddMedicine), id);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicine([FromBody] Medicine medicine, [FromRoute] int id)
        {
            await _medicineServices.UpdateMedicine(id, medicine);
            return Ok();

        }
        //[HttpPatch("{id}")]
        //public async Task<IActionResult> UpdateMedicineByStock([FromBody] JsonPatchDocument medicine, [FromRoute] int id)
        //{
        //    await _medicineRepository.UpdateMedicineByStock(id, medicine);
        //    return Ok();

        //}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine([FromRoute] int id)
        {
            await _medicineServices.DeleteMedicine(id);
            return Ok();
        }
    }
}
