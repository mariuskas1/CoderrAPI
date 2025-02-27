using Coderr.API.Models.DTOs;
using Coderr.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Coderr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.username,
                Email = registerRequestDTO.username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDTO.password);

            if (identityResult.Succeeded)
            {
                if (registerRequestDTO.roles != null && registerRequestDTO.roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered.");
                    }
                }
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDTO.username);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDTO.password);

                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDTO
                        {
                            JwtToken = jwtToken,
                        };

                        return Ok(jwtToken);
                    }
                }
            }

            return BadRequest("Username or Password incorrect.");
        }
    }
}
