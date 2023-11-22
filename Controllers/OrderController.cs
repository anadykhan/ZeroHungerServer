using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZeroHungerVS.Models;
using ZeroHungerVS.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZeroHungerVS.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly OrdersServices _ordersServices;

        public OrderController(OrdersServices ordersServices)
        {
            _ordersServices = ordersServices;
        }

        [HttpGet]
        public async Task<List<Order>> GetOrders()
        {
            return await _ordersServices.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] Order order)
        {
            await _ordersServices.CreateAsync(order);
            return CreatedAtAction(nameof(GetOrders), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(string id, [FromBody] Order order)
        {
            await _ordersServices.UpdateAsync(id, order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            await _ordersServices.DeleteAsync(id);
            return NoContent();
        }
    }
}

