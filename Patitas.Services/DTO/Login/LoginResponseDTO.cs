using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Login
{
    public class LoginResponseDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ProfilePicture { get; set; } = string.Empty;
        public string RoleName { get;set; } = string.Empty;
        public string TokenAccess { get; set; } = string.Empty;
    }
}
