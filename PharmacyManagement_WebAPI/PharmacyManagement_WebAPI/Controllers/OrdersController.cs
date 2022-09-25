using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmacyManagement_WebAPI.Models;
using PharmacyManagement_WebAPI.Repository;
using PharmacyManagement_WebAPI.Services;

namespace PharmacyManagement_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public readonly OrderServices _orderServices;

        public OrdersController(OrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderServices.GetAllOrders();
            return Ok(orders);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            var id = await _orderServices.AddOrder(order);
            return CreatedAtAction(nameof(AddOrder), id);
        }
    }
}
