using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Turno
{
    public class TurnoDetalleRefugioDTO
    {
        public int Id { get; set; }
        public string FechaTurno { get; set; } = string.Empty;
        public string HoraTurno { get; set; } = string.Empty;
        public int SolicitudId { get; set; }
        public int AdoptanteId { get; set; }
        public string NombreAdoptante { get; set; } = string.Empty;
        public string EmailAdoptante { get; set;} = string.Empty;
        public string? Telefono { get; set;} = string.Empty;
        public bool EstaConfirmado { get; set; }
        public bool Asistio { get; set; }
        public bool EstaActivo { get; set; }
        public bool PorReprogramar { get; set; }
        public string MotivoDeReprogramacion { get; set; } = string.Empty;
    }
}
