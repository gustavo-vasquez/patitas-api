using Patitas.Services.DTO.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Register
{
    public class RegisterResponseDTO
    {
        public string Message { get; set; } = string.Empty;
        public string Welcome { get; set; } = string.Empty;
        public LoginResponseDTO LoginResponse { get; set; } = null!;
    }
}
