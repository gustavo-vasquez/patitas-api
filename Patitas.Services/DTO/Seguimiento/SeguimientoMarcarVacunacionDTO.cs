using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Seguimiento
{
    public class SeguimientoMarcarVacunacionDTO
    {
        [Required(ErrorMessage = "El id del seguimiento es obligatorio.")]
        public int SeguimientoId { get; set; }

        [Required(ErrorMessage = "El id de la solicitud es obligatoria.")]
        public int SolicitudId { get; set; }
    }
}
