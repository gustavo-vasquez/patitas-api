using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patitas.Services.Contracts;
using Patitas.Services.Contracts.Manager;
using Patitas.Services.DTO.Login;
using Patitas.Services.DTO.Registro;
using Patitas.Services.DTO.Registro.Roles;
using Patitas.Services.Helpers.Enums;

namespace Patitas.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public AuthenticationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginData)
        {
            try
            {
                LoginResponseDTO userInfo = await _serviceManager.AuthenticationService.Login(loginData.Email, loginData.Password);
                return Ok(userInfo);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("registro/adoptante")]
        public async Task<IActionResult> RegistroAdoptante([FromBody] RegistroAdoptanteDTO datosDeRegistro)
        {
            try
            {
                RegistroResponseDTO resultado = await _serviceManager.AuthenticationService.RegistrarCuenta(datosDeRegistro, RolTypes.ADOPTANTE);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("registro/refugio")]
        public async Task<IActionResult> RegistroRefugio([FromBody] RegistroRefugioDTO datosDeRegistro)
        {
            try
            {
                RegistroResponseDTO resultado = await _serviceManager.AuthenticationService.RegistrarCuenta(datosDeRegistro, RolTypes.REFUGIO);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("registro/veterinaria")]
        public async Task<IActionResult> RegistroVeterinaria([FromBody] RegistroVeterinariaDTO datosDeRegistro)
        {
            try
            {
                RegistroResponseDTO resultado = await _serviceManager.AuthenticationService.RegistrarCuenta(datosDeRegistro, RolTypes.VETERINARIA);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("prueba")]
        public IActionResult Prueba()
        {
            return Ok("Este es un recurso protegido.");
        }

        [HttpGet]
        [Route("prueba-enum/{rol}")]
        public IActionResult PruebaEnum(RolTypes rolType)
        {
            return Ok(rolType);
        }
    }
}
