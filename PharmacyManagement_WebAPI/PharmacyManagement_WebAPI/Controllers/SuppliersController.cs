using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyManagement_WebAPI.Models;
using PharmacyManagement_WebAPI.Repository;
using PharmacyManagement_WebAPI.Services;

namespace PharmacyManagement_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        public readonly SupplierServices _supplierServices;
        public SuppliersController(SupplierServices supplierServices)
        {
            _supplierServices = supplierServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            try
            {
                var suppliers = await _supplierServices.GetAllSuppliers();
                return Ok(suppliers);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("")]
        public async Task<IActionResult> AddSupplier([FromBody] Supplier supplier)
        {
            try
            {
                var id = await _supplierServices.AddSupplier(supplier);
                return CreatedAtAction(nameof(AddSupplier), id);
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier([FromBody] Supplier supplier, [FromRoute] int id)
        {
            try
            {
                if (id != supplier.SupplierId)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _supplierServices.UpdateSupplier(id, supplier);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier([FromRoute] int id)
        {
            try
            {
                await _supplierServices.DeleteSupplier(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
