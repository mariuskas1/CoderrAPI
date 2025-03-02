using AutoMapper;
using Coderr.API.Data;
using Coderr.API.Models.Domain;
using Coderr.API.Models.DTOs;
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
        private readonly IMapper mapper;

        public ProfilesController(CoderrDbContext dbContext, IUserProfileRepository userProfileRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.userProfileRepository = userProfileRepository;
            this.mapper = mapper;
        }

        [HttpGet("/profile/{id:guid}")]
        public async Task<IActionResult> GetProfileById(Guid id)
        {
            var profileDomain = await userProfileRepository.GetByIdAsync(id);
            if (profileDomain == null) return NotFound();
            var profileDTO = mapper.Map<UserProfileDTO>(profileDomain);
            return Ok(profileDTO);
        }

        [HttpGet("business")]
        public async Task<IActionResult> GetBusinessProfiles()
        {
            var businessProfilesDomain = await userProfileRepository.GetProfilesByTypeAsync(UserProfile.UserType.Business);
            var businessProfilesDTO = mapper.Map<UserProfileDTO>(businessProfilesDomain);
            return Ok(businessProfilesDTO);
        }

        [HttpGet("customer")]
        public async Task<IActionResult> GetCustomerProfiles()
        {
            var customerProfilesDomain = await userProfileRepository.GetProfilesByTypeAsync(UserProfile.UserType.Customer);
            var customerProfilesDTO = mapper.Map<UserProfileDTO>(customerProfilesDomain);
            return Ok(customerProfilesDTO);
        }

    }
}
