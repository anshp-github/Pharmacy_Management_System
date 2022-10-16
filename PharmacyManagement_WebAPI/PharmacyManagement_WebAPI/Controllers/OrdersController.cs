﻿using Microsoft.AspNetCore.Http;
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
            try
            {
                var orders = await _orderServices.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("")]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            try
            {
                var id = await _orderServices.AddOrder(order);
                return CreatedAtAction(nameof(AddOrder), id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("From/{From}/To/{To}")]
        public async Task<IActionResult> GetOrdersReport([FromRoute] DateTime From, [FromRoute] DateTime To)
        {
            try
            {
                var orders = await _orderServices.GetOrdersReport(From, To);
                return Ok(orders);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order, [FromRoute] int id)
        {
            try
            {
                if (id != order.OrderId)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                await _orderServices.UpdateOrder(id, order);

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("confirmation")]
        public async Task<IActionResult> GetOrdersConfirmation()
        {
            try
            {
                var orders = await _orderServices.GetOrdersConfirmation();
                return Ok(orders);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}