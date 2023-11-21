using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Seguimiento
{
    public class SeguimientoTarjetaDTO
    {
        public int Id { get; set; }
        public string FechaAsignada { get; set; } = string.Empty;
        public string HoraAsignada { get; set; } = string.Empty;
        public bool EstaAplicada { get; set; }
        public bool EstaVencido { get; set; }
        public byte NroDosis { get; set; }
        public bool PorReprogramar { get; set; }
        public string MotivoDeReprogramacion { get; set; } = string.Empty;
        public bool EstaActivo { get; set; }
        public int Id_SolicitudDeAdopcion { get; set; }
        public int Id_Vacuna { get; set; }
        public int Id_Veterinaria { get; set; }
        public string NombreAdoptante { get; set; } = string.Empty;
        public string NombreVeterinaria { get; set; } = string.Empty;
    }
}
