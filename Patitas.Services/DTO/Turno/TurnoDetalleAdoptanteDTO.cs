using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Turno
{
    public class TurnoDetalleAdoptanteDTO
    {
        public int Id { get; set; }
        public string FechaTurno { get; set; } = string.Empty;
        public string HoraTurno { get; set; } = string.Empty;
        public int SolicitudId { get; set; }
        public bool SolicitudEnEtapaDeSeguimiento { get; set; }
        public int RefugioId { get; set; }
        public string NombreRefugio { get; set; } = string.Empty;
        public bool EstaConfirmado { get; set; }
        public bool Asistio { get; set; }
        public string InformeDeVisita { get; set; } = string.Empty;
        public bool EstaActivo { get; set; }
        public bool PorReprogramar { get; set; }
        public string MotivoDeReprogramacion { get; set; } = string.Empty;
    }
}
