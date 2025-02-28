using AutoMapper;
using Coderr.API.Data;
using Coderr.API.Models.DTOs.Offer;
using Coderr.API.Models.DTOs.Order;
using Coderr.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coderr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly CoderrDbContext dbContext;
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrdersController(CoderrDbContext dbContext, IOrderRepository orderRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetAllOrdersResponseDTO>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var ordersDomain = await orderRepository.GetAllAsync();
            var ordersDTO = mapper.Map<List<GetAllOrdersResponseDTO>>(ordersDomain);
            return Ok(ordersDTO);
        }

    }
}
