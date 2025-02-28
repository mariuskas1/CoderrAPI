using AutoMapper;
using Coderr.API.Data;
using Coderr.API.Models.Domain;
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

        [HttpPost]
        [ProducesResponseType(typeof(AddOfferResponseDTO), 201)]
        public async Task<IActionResult> Create([FromBody] AddOrderRequestDTO addOrderRequestDTO)
        {
            var orderDomainModel = mapper.Map<Order>(addOrderRequestDTO);
            orderDomainModel = await orderRepository.CreateAsync(orderDomainModel);
            var addOrderResponseDTO = mapper.Map<AddOrderResponseDTO>(orderDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = addOrderResponseDTO }, addOrderResponseDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(typeof(GetAllOrdersResponseDTO), 200)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var order = await orderRepository.GetByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            var orderDTO = mapper.Map<GetAllOrdersResponseDTO>(order);
            return Ok(orderDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOrderRequestDTO updateOrderRequestDTO)
        {
            var orderDomainModel = mapper.Map<Order>(updateOrderRequestDTO);
            orderDomainModel = await orderRepository.UpdateAsync(id, orderDomainModel);
            if (orderDomainModel == null)
            {
                return NotFound();
            }
            var orderDTO = mapper.Map<GetAllOrdersResponseDTO>(orderDomainModel);
            return Ok(orderDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var orderDomainModel = await orderRepository.DeleteAsync(id);

            if (orderDomainModel == null)
            {
                return NotFound();
            }
            return Ok();
        }

        
    }
}
