using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Turno
{
    public class TurnoTarjetaDTO
    {
        public int Id { get; set; }
        public string FechaProgramada { get; set; } = string.Empty;
        public string HoraProgramada { get; set; } = string.Empty;
        public bool EstaConfirmado { get; set; }
        public bool Asistio { get; set; }
        public bool EstaActivo { get; set; }
        public bool PorReprogramar { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}
