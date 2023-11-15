using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Turno
{
    public class TurnoCreateDTO
    {
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Fecha { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int? Hora { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int? Minuto { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int? SolicitudDeAdopcionId { get; set; }
    }
}
