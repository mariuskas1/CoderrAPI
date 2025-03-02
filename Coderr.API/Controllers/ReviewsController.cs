using AutoMapper;
using Coderr.API.Data;
using Coderr.API.Models.DTOs;
using Coderr.API.Models.DTOs.Order;
using Coderr.API.Repositories;
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
    }
}
