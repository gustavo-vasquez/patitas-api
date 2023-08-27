using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Patitas.Services.Contracts;
using Patitas.Services.Contracts.Manager;
using Patitas.Services.DTO.Login;
using Patitas.Services.DTO.Register;

namespace Patitas.Presentation.Controllers
{
    [Route("/api/auth")]
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
            catch
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerData)
        {
            RegisterResponseDTO result = await _serviceManager.AuthenticationService.Register(registerData);
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("prueba")]
        public IActionResult Prueba()
        {
            return Ok("recurso protegido.");
        }
    }
}
