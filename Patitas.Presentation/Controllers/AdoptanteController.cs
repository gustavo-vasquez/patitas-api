using Microsoft.AspNetCore.Mvc;
using Patitas.Services.Contracts.Manager;
using Patitas.Services.DTO.Adoptante;

namespace Patitas.Presentation.Controllers
{   
    [ApiController]
    [Route("api/adoptantes")]
    public class AdoptanteController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public AdoptanteController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        [Route("{adoptanteId}/perfil")]
        public async Task<IActionResult> GetPerfil([FromRoute] int adoptanteId)
        {
            try
            {
                AdoptantePerfilCompletoDTO perfil = await _serviceManager.AdoptanteService.GetPerfilDelAdoptante(adoptanteId);
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
