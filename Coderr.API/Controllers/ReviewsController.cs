﻿using AutoMapper;
using Coderr.API.Data;
using Coderr.API.Models.Domain;
using Coderr.API.Models.DTOs;
using Coderr.API.Models.DTOs.Order;
using Coderr.API.Repositories;
using Microsoft.AspNetCore.Components.Forms.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coderr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly CoderrDbContext dbContext;
        private readonly IReviewRepository reviewRepository;
        private readonly IMapper mapper;

        public ReviewsController(CoderrDbContext dbContext, IReviewRepository reviewRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.reviewRepository = reviewRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Guid business_user_id, [FromQuery] string? ordering)
        {
            var reviewsDomain = await reviewRepository.GetAllAsync(business_user_id, ordering);
            var reviewsDTO = mapper.Map<List<ReviewDTO>>(reviewsDomain);
            return Ok(reviewsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReviewDTO reviewDTO)
        {
            var reviewDomainModel = mapper.Map<Review>(reviewDTO);
            reviewDomainModel = await reviewRepository.CreateAsync(reviewDomainModel);
            var reviewResponseDTO = mapper.Map<ReviewDTO>(reviewDomainModel);
            return CreatedAtAction(nameof(GetById), new { id = reviewResponseDTO.id }, reviewResponseDTO);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var reviewDomain = await reviewRepository.GetByIdAsync(id);
            if (reviewDomain == null) {
                return NotFound();
            }
            var reviewDTO = mapper.Map<ReviewDTO>(reviewDomain);
            return Ok(reviewDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromBody] ReviewDTO reviewDTO, [FromRoute] Guid id)
        {
            var reviewDomainModel = mapper.Map<Review>(reviewDTO);
            reviewDomainModel = await reviewRepository.UpdateAsync(id, reviewDomainModel);
            if (reviewDomainModel == null)
            {
                return NotFound();
            }
            var reviewResponseDTO = mapper.Map<ReviewDTO>(reviewDomainModel);
            return Ok(reviewResponseDTO);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var reviewDomainModel = await reviewRepository.DeleteAsync(id);
            if (reviewDomainModel == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
