using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Seguimiento
{
    public class SeguimientoDetalleVeterinariaDTO
    {
        public int Id { get; set; }
        public string FechaAsignada { get; set; } = string.Empty;
        public string HoraAsignada { get; set; } = string.Empty;
        public int SolicitudId { get; set; }
        public bool SolicitudEnEtapaDeSeguimiento { get; set; }
        public int AdoptanteId { get; set; }
        public int RefugioId { get; set; }
        public string NombreAdoptante { get; set; } = string.Empty;
        public string EmailAdoptante { get; set; } = string.Empty;
        public string? Telefono { get; set; } = string.Empty;
        public bool EstaConfirmado { get; set; }
        public bool EstaAplicada { get; set; }
        public string NombreVacuna { get; set; } = string.Empty;
        public byte NroDosis { get; set; }
        public bool EstaActivo { get; set; }
        public bool PorReprogramar { get; set; }
        public string MotivoDeReprogramacion { get; set; } = string.Empty;
        public int Id_SolicitudDeAdopcion { get; set; }
        public int Id_Vacuna { get; set; }
        public int Id_Veterinaria { get; set; }
    }
}
