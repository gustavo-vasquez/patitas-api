using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Patitas.Services.Contracts.Manager;

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
    }
}
