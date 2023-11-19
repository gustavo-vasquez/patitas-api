using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Turno
{
    public class TurnoMarcarAsistenciaDTO
    {
        [Required(ErrorMessage = "El id del turno es obligatorio.")]
        public int TurnoId { get; set; }

        [Required(ErrorMessage = "El informe de la visita es obligatorio.")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres.")]
        public string InformeDeVisita { get; set; } = string.Empty;
    }
}
