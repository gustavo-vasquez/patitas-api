using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patitas.Services.Contracts.Manager;
using Patitas.Services.DTO.SolicitudDeAdopcion;

namespace Patitas.Presentation.Controllers
{
    [Route("api/solicitudes-adopcion")]
    [ApiController]
    public class SolicitudDeAdopcionController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public SolicitudDeAdopcionController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        [Authorize(Roles = "Adoptante")]
        public async Task<IActionResult> CreateSolicitud([FromBody] FormularioPreAdopcionDTO formularioPreAdopcionDTO)
        {
            try
            {
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
