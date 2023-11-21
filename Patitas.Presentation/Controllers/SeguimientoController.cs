using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patitas.Services.Contracts.Manager;
using Patitas.Services.DTO.Seguimiento;

namespace Patitas.Presentation.Controllers
{
    [Route("api/seguimientos")]
    [ApiController]
    public class SeguimientoController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public SeguimientoController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("veterinaria")]
        [Authorize(Roles = "Veterinaria")]
        public async Task<IActionResult> GetSeguimientosDeVacunacion()
        {
            try
            {
                SeguimientoResponseDTO seguimientos = await _serviceManager.SeguimientoService
                    .GetSeguimientosVeterinaria(HttpContext.User.Identity);

                return Ok(seguimientos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Veterinaria")]
        public async Task<IActionResult> CreateSeguimiento([FromBody] SeguimientoCreateDTO seguimientoDTO)
        {
            try
            {
                await _serviceManager.SeguimientoService.CreateCita(HttpContext.User.Identity, seguimientoDTO);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                if (ex is DirectoryNotFoundException)
                    return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
