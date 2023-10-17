using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patitas.Services.Contracts;
using Patitas.Services.Contracts.Manager;
using Patitas.Services.DTO.Login;
using Patitas.Services.DTO.Registro;
using Patitas.Services.DTO.Registro.Roles;
using Patitas.Services.Helpers.Enums;
using System.Net;
using System.Security.Claims;

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
                LoginResponseDTO? userInfo = await _serviceManager.AuthenticationService.Login(loginData.Email, loginData.Password);

                if (userInfo is null)
                    return NotFound("Usuario y/o contraseña incorrecta.");

                return Ok(userInfo);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("registro/adoptante")]
        public async Task<IActionResult> RegistroAdoptante([FromBody] RegistroAdoptanteDTO datosDeRegistro)
        {
            try
            {
                RegistroResponseDTO? resultado = await _serviceManager.AuthenticationService.RegistrarCuenta(datosDeRegistro, RolTypes.ADOPTANTE);
                
                if (resultado is null)
                    return Conflict("El email o nombre de usuario ya se encuentra registrado.");

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("registro/refugio")]
        public async Task<IActionResult> RegistroRefugio([FromBody] RegistroRefugioDTO datosDeRegistro)
        {
            try
            {
                RegistroResponseDTO? resultado = await _serviceManager.AuthenticationService.RegistrarCuenta(datosDeRegistro, RolTypes.REFUGIO);

                if (resultado is null)
                    return Conflict("El email o nombre de usuario ya se encuentra registrado.");

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("registro/veterinaria")]
        public async Task<IActionResult> RegistroVeterinaria([FromBody] RegistroVeterinariaDTO datosDeRegistro)
        {
            try
            {
                RegistroResponseDTO? resultado = await _serviceManager.AuthenticationService.RegistrarCuenta(datosDeRegistro, RolTypes.VETERINARIA);

                if (resultado is null)
                    return Conflict("El email o nombre de usuario ya se encuentra registrado.");

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("prueba")]
        [Authorize(Roles = "Refugio")]
        public IActionResult Prueba()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var email = string.Empty;

            if(identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                email = identity.FindFirst(ClaimTypes.Email)?.Value;
            }

            return Ok(email);
        }
    }
}
