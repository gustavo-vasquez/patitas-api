using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patitas.Services.Contracts.Manager;
using Patitas.Services.DTO.SolicitudDeAdopcion;
using System.Security.Claims;

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
        public async Task<IActionResult> CreateSolicitud([FromBody] SolicitudDeAdopcionRequestDTO solicitudDeAdopcionRequestDTO)
        {
            try
            {
                ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;
                await _serviceManager.SolicitudDeAdopcionService.CreateSolicitud(solicitudDeAdopcionRequestDTO, identity!);
                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("adoptante")]
        [Authorize(Roles = "Adoptante")]
        public async Task<IActionResult> GetMisSolicitudes()
        {
            try
            {
                SolicitudDeAdopcionResponseDTO solicitudesDeAdopcion = await _serviceManager.SolicitudDeAdopcionService
                    .GetSolicitudes(
                        HttpContext.User.Identity,
                        Services.Helpers.Enums.RolTypes.ADOPTANTE);

                return Ok(solicitudesDeAdopcion);
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                    return Unauthorized(ex.Message);

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("aprobacion/{solicitudId}")]
        [Authorize(Roles = "Refugio")]
        public async Task<IActionResult> AprobarSolicitud([FromRoute] int solicitudId)
        {
            try
            {
                await _serviceManager.SolicitudDeAdopcionService.AprobarSolicitudDeAdopcion(HttpContext.User.Identity, solicitudId);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
