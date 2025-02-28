using Coderr.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coderr.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class OrderCountController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrderCountController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        [Route("order-count/{business_user_id:guid}")]
        public async Task<IActionResult> GetOrderCount(Guid business_user_id)
        {
            var orderCount = await orderRepository.GetOrderCountAsync(business_user_id);
            return Ok(new { total_orders = orderCount });
        }

        [HttpGet]
        [Route("completed-order-count/{business_user_id:guid}")]
        public async Task<IActionResult> GetCompletedOrderCount(Guid business_user_id)
        {
            var completedOrderCount = await orderRepository.GetCompletedOrderCountAsync(business_user_id);
            return Ok(new { completed_orders = completedOrderCount });
        }
    }
}
