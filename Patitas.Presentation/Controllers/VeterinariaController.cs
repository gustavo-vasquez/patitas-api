﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Patitas.Services.Contracts.Manager;
using Patitas.Services.DTO.Veterinaria;

namespace Patitas.Presentation.Controllers
{
    [Route("api/veterinaria")]
    [ApiController]
    public class VeterinariaController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly IWebHostEnvironment _env; // para manejar las rutas de directorios

        public VeterinariaController(IServiceManager serviceManager, IWebHostEnvironment env)
        {
            _serviceManager = serviceManager;
            _env = env;
        }

        [HttpGet]
        [Route("images/{filename}")]
        public IActionResult GetVeterinariaImage([FromRoute] string filename)
        {
            string path = Path.Combine(_env.WebRootPath, $"images/usuarios/veterinarias", filename);
            FileStream imageFileStream = System.IO.File.OpenRead(path);

            FileExtensionContentTypeProvider provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(filename, out string? contentType))
                contentType = "application/octet-stream";

            return File(imageFileStream, contentType);
        }

        [HttpGet]
        [Route("vacunas/{especieId}")]
        public async Task<IActionResult> GetListaDeVacunas([FromRoute] int especieId)
        {
            try
            {
                IEnumerable<VacunaComboDTO> vacunaComboDTO = await _serviceManager.VeterinariaService.GetVacunaCombo(especieId);
                return Ok(vacunaComboDTO);
            }
            catch(Exception ex)
            {
                if(ex is DirectoryNotFoundException)
                    return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("plan-de-vacunacion/{solicitudId}")]
        [Authorize(Roles = "Veterinaria")]
        public async Task<IActionResult> CreatePlanDeVacunacion([FromBody] IEnumerable<PlanDeVacunacionRequestDTO> vacunasDelPlan, [FromRoute] int solicitudId)
        {
            try
            {
                await _serviceManager.VeterinariaService.CreateNuevoPlanDeVacunacion(HttpContext.User.Identity, vacunasDelPlan, solicitudId);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                if(ex is DirectoryNotFoundException)
                    return NotFound(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}