using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patitas.Services.Contracts.Manager;
using Patitas.Services.DTO.Barrio;

namespace Patitas.Presentation.Controllers
{
    [Route("api/barrios")]
    [ApiController]
    public class BarrioController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public BarrioController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetBarrios()
        {
            IEnumerable<BarrioResponseDTO> barrios = await _serviceManager.BarrioService.GetBarrios();
            return Ok(barrios);
        }
    }
}
