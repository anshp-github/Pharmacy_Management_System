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
    [Authorize]
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
            try
            {
                var medicines = await _medicineServices.GetAllMedicines();
                return Ok(medicines);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("{MedName}")]
        public async Task<IActionResult> GetMedicine([FromRoute] string MedName)
        {
            try
            {
                var medcine = await _medicineServices.GetMedicineByName(MedName);
                if (!ModelState.IsValid)
                {
                    return BadRequest(medcine);
                }

                if (medcine == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(medcine);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> AddMedicine([FromBody] Medicine medicine)
        {
            try
            {
                var id = await _medicineServices.AddMedicine(medicine);
                return CreatedAtAction(nameof(AddMedicine), id);
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicine([FromBody] Medicine medicine, [FromRoute] int id)
        {
            try
            {
                if (id != medicine.MedicineId)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _medicineServices.UpdateMedicine(id, medicine);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

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
            try
            {
                await _medicineServices.DeleteMedicine(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
