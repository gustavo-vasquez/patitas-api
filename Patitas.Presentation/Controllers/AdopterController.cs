using Microsoft.AspNetCore.Mvc;
using Patitas.Services.Contracts.Manager;
using Patitas.Services.DTO;

namespace Patitas.Presentation.Controllers
{
    [Route("api/adopter")]
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
