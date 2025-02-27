using AutoMapper;
using Coderr.API.Data;
using Coderr.API.Models.Domain;
using Coderr.API.Models.DTOs;
using Coderr.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coderr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly CoderrDbContext dbContext;
        private readonly IOfferRepository offerRepository;
        private readonly IMapper mapper;

        public OffersController(CoderrDbContext dbContext, IOfferRepository offerRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.offerRepository = offerRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<GetAllOffersResponseDTO>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var offersDomain = await offerRepository.GetAllAsync();
            var offersDTO = mapper.Map<List<GetAllOffersResponseDTO>>(offersDomain);
            return Ok(offersDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddOfferRequestDTO addOfferRequestDTO)
        {

        }
    }
}
