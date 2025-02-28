using Coderr.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coderr.API.Controllers
{
    [Route("api/base-info")]
    [ApiController]
    public class BaseInfoController : ControllerBase
    {
        private readonly IBaseInfoRepository baseInfoRepository;

        public BaseInfoController(IBaseInfoRepository baseInfoRepository)
        {
            this.baseInfoRepository = baseInfoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBaseInfo()
        {
            var baseInfo = await baseInfoRepository.GetBaseInfoAsync();
            return Ok(baseInfo);
        }
    }
}
