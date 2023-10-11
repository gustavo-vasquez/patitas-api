using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Patitas.Services.Contracts.Manager;
using Patitas.Services.DTO.Refugio;

namespace Patitas.Presentation.Controllers
{
    [ApiController]
    [Route("api/refugios")]
    public class RefugioController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IWebHostEnvironment _env;

        public RefugioController(IServiceManager serviceManager, IWebHostEnvironment env)
        {
            _serviceManager = serviceManager;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> GetRefugios()
        {
            ExplorarRefugiosDTO explorarRefugios = await _serviceManager.RefugioService.ExplorarRefugios();
            return Ok(explorarRefugios);
        }

        [HttpGet]
        [Route("{refugioId}")]
        public async Task<IActionResult> GetRefugio([FromRoute] int refugioId)
        {
            try
            {
                RefugioInfoBasicaDTO result = await _serviceManager.RefugioService.GetInformacionBasicaDelRefugio(refugioId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("buscar")]
        public async Task<IActionResult> SearchRefugioBy([FromQuery] string? nombre, [FromQuery] string? barrio)
        {
            IEnumerable<RefugioDTO> refugiosDTO = await _serviceManager.RefugioService.BuscarRefugios(nombre, barrio);
            return Ok(refugiosDTO);
        }

        [HttpGet]
        [Route("{refugioId}/animales")]
        public async Task<IActionResult> GetAnimales([FromRoute] int refugioId)
        {
            try
            {
                RefugioResponseDTO result = await _serviceManager.RefugioService.GetAnimalesDelRefugio(refugioId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{refugioId}/comentarios")]
        public async Task<IActionResult> GetComentarios([FromRoute] int refugioId)
        {
            try
            {
                RefugioResponseDTO result = await _serviceManager.RefugioService.GetComentariosDelRefugio(refugioId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{refugioId}/veterinarias-asociadas")]
        public async Task<IActionResult> GetVeterinariasAsociadas([FromRoute] int refugioId)
        {
            try
            {
                RefugioResponseDTO result = await _serviceManager.RefugioService.GetVeterinariasAsociadas(refugioId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{refugioId}/mas-informacion")]
        public async Task<IActionResult> GetMasInformacion([FromRoute] int refugioId)
        {
            try
            {
                RefugioResponseDTO result = await _serviceManager.RefugioService.GetInformacionCompleta(refugioId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{refugioId}/animales/images/{filename}")]
        public IActionResult GetAnimalImage([FromRoute] int refugioId, [FromRoute] string filename)
        {
            string path = Path.Combine(_env.WebRootPath, $"images/animales/refugios/{refugioId}", filename);
            //var path = _env.WebRootFileProvider.GetFileInfo($"images/animales/refugios/{refugioId}/{filename}");
            FileStream imageFileStream = System.IO.File.OpenRead(path);

            FileExtensionContentTypeProvider provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(filename, out string? contentType))
                contentType = "application/octet-stream";

            return File(imageFileStream, contentType);
        }
    }
}
