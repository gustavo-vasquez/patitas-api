using Patitas.Services.DTO.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Registro
{
    public class RegistroResponseDTO
    {
        public string Resultado { get; set; } = string.Empty;
        public string Bienvenida { get; set; } = string.Empty;
        public LoginResponseDTO? LoginResponse { get; set; } = null!;
    }
}
