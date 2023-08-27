using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Register
{
    public class RegisterRequestDTO
    {
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MinLength(6, ErrorMessage = "Mínimo 6 caracteres.")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string Username {  get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "El email no es válido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int BarrioId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MinLength(6, ErrorMessage = "Mínimo 6 caracteres.")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coinciden.")]
        public string ComparePassword { get; set; } = string.Empty;
    }
}
