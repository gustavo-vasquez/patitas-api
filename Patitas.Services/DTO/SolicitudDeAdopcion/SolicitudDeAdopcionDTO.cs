using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.SolicitudDeAdopcion
{
    public class SolicitudDeAdopcionDTO
    {
        public int Id { get; set; }
        public string FechaInicio { get; set; } = string.Empty;
        public string HoraInicio { get; set; } = string.Empty;
        public string? FechaFinalizacion { get; set; }
        public string? HoraFinalizacion { get; set; }
        public bool Aprobada { get; set; }
        public bool EstaActivo { get; set; }
        public int Id_Adoptante { get; set; }
        public int Id_Animal { get; set; }
        public int Id_Refugio { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public string NombreAnimal { get; set; } = string.Empty;
        public string FotoAnimal { get; set; } = string.Empty;
        public bool ExisteAlgunTurno { get; set; }
        public string? FechaCancelacion { get; set; }
        public string? HoraCancelacion { get; set; }
    }
}
