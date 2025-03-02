using Coderr.API.Data;
using Coderr.API.Models.Domain;
using Coderr.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coderr.API.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly CoderrDbContext dbContext;
        private readonly IUserProfileRepository userProfileRepository;

        public ProfilesController(CoderrDbContext dbContext, IUserProfileRepository userProfileRepository)
        {
            this.dbContext = dbContext;
            this.userProfileRepository = userProfileRepository;
        }

        [HttpGet("/profile/{id:guid}")]
        public async Task<IActionResult> GetProfileById(Guid id)
        {
            var profile = await userProfileRepository.GetByIdAsync(id);
            if (profile == null) return NotFound();
            return Ok(profile);
        }

        [HttpGet("business")]
        public async Task<IActionResult> GetBusinessProfiles()
        {
            var businessProfiles = await userProfileRepository.GetProfilesByTypeAsync(UserProfile.UserType.Business);
            return Ok(businessProfiles);
        }

        [HttpGet("customer")]
        public async Task<IActionResult> GetCustomerProfiles()
        {
            var businessProfiles = await userProfileRepository.GetProfilesByTypeAsync(UserProfile.UserType.Customer);
            return Ok(businessProfiles);
        }

    }
}
