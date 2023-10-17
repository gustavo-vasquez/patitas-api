using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Login
{
    public class LoginResponseDTO
    {
        public string NombreDeUsuario { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? FotoDePerfil { get; set; } = string.Empty;
        public string Barrio { get; set; } = string.Empty;
        public string Rol { get;set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
    }
}
