using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Registro.Roles
{
    public class RegistroRefugioDTO : RegistroRequestDTO
    {
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string RazonSocial { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string NombreResponsable { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string ApellidoResponsable { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public override string? Telefono { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(46, ErrorMessage = "Máximo 46 caracteres.")]
        public override string? Calle { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(4, ErrorMessage = "Máximo 4 caracteres.")]
        public override string? Altura { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string DiasDeAtencion { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(2, ErrorMessage = "Hora de apertura no válida.")]
        public string HoraApertura { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [MaxLength(2, ErrorMessage = "Hora de cierre no válida.")]
        public string HoraCierre { get; set; } = string.Empty;
        protected override bool EstaActivo { get; set; } = false;
    }
}
