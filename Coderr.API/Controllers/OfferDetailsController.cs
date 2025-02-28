using AutoMapper;
using Coderr.API.Data;
using Coderr.API.Models.Domain;
using Coderr.API.Models.DTOs.Offer;
using Coderr.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coderr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDetailsController : ControllerBase
    {
        private readonly CoderrDbContext dbContext;
        private readonly IOfferDetailsRepository offerDetailsRepository;
        private readonly IMapper mapper;

        public OfferDetailsController(CoderrDbContext dbContext, IOfferDetailsRepository offerDetailsRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.offerDetailsRepository = offerDetailsRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult?> GetById([FromRoute] Guid id)
        {
            var offerDetailsDomain = await offerDetailsRepository.GetByIdAsync(id);
            if (offerDetailsDomain == null)
            {
                return NotFound();
            }
            var offerDetailsDTO = mapper.Map<GetOfferDetailsResponseDTO>(offerDetailsDomain);
            return Ok(offerDetailsDTO);
        }

    }
}
