using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtomatMachine.Application.Abstarct;
using OtomatMachine.Domain.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtomatMachine.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder(OrderDtoForAdd orderDtoForAdd)
        {
            var addedOrder = await _orderService.AddOrder(orderDtoForAdd);
            return Ok(addedOrder);
        }
    }
}
