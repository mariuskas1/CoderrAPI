using System.Dynamic;
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
        [ProducesResponseType(typeof(AddOfferResponseDTO), 201)]
        public async Task<IActionResult> Create([FromBody] AddOfferRequestDTO addOfferRequestDTO)
        {
            var offerDomainModel = mapper.Map<Offer>(addOfferRequestDTO);
            offerDomainModel = await offerRepository.CreateAsync(offerDomainModel);
            var addOfferResponseDTO = mapper.Map<AddOfferResponseDTO>(offerDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = addOfferResponseDTO.id }, addOfferResponseDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(typeof(GetSingleOfferResponseDTO), 200)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var offer = await offerRepository.GetByIdAsync(id);

            if (offer == null)
            {
                return NotFound();
            }

            var offerDTO = mapper.Map<GetSingleOfferResponseDTO>(offer);
            return Ok(offerDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ProducesResponseType(typeof(UpdateOfferResponseDTO), 200)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOfferRequestDTO updateOfferRequestDTO)
        {
            var offerDomainModel = mapper.Map<Offer>(updateOfferRequestDTO);
            offerDomainModel = await offerRepository.UpdateAsync(id, offerDomainModel);

            if (offerDomainModel == null)
            {
                return NotFound();
            }

            var offerDTO = mapper.Map<UpdateOfferResponseDTO>(offerDomainModel);
            return Ok(offerDTO);
        }
    }
}
