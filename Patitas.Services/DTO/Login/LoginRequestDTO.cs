using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Login
{
    public class LoginRequestDTO
    {
        [Required(ErrorMessage = "El campo email es obligatorio.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo password es obligatorio.")]
        public string Password { get; set; } = string.Empty;
    }
}
