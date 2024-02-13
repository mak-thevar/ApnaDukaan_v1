using ApnaDukaan_v1.BLL.DTOs;
using ApnaDukaan_v1.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApnaDukaan_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            var userId = 1;
            var isAdmin = true; //User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Role);
            if (isAdmin)
            {
                var orders = await this.orderService.GetAll();
                return Ok(orders);
            }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderRequestDTO orderRequestDTO)
        {
            var userId = 2;  //User.Claims.SingleOrDefault(x=>x.Type == ClaimTypes.id)

            var result = await this.orderService.Add(userId, orderRequestDTO);
            return Ok(result);
        }
    }
}
