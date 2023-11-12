﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patitas.Services.Contracts.Manager;
using Patitas.Services.DTO.Adoptante;

namespace Patitas.Presentation.Controllers
{   
    [ApiController]
    [Route("api/adoptante")]
    public class AdoptanteController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public AdoptanteController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpGet]
        [Route("perfil")]
        [Authorize(Roles = "Adoptante")]
        public async Task<IActionResult> GetPerfil()
        {
            try
            {
                AdoptantePerfilCompletoDTO perfil = await _serviceManager.AdoptanteService.GetPerfilDelAdoptante(HttpContext.User.Identity);
                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
