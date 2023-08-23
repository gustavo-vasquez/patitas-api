using Microsoft.AspNetCore.Mvc;
using Patitas.Services.Contracts;
using Patitas.Services.DTO;

namespace Patitas.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdopterController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public AdopterController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfileInfo()
        {
            try
            {
                AdopterProfileInfoDTO profile = await _serviceManager.AdopterService.GetAdopterProfileInfo(1);
                return Ok(profile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
