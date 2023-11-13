using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Adoptante
{
    public class AdopcionDetalleResponseDTO
    {
        public int NroSolicitud { get; set; }
        public bool SnAprobada { get; set; }
        public string? FechaInicio { get; set; }
        public string? HoraInicio { get; set; }
        public int AnimalId { get; set; }
        public string NombreAnimal { get; set; } = string.Empty;
        public string RazaAnimal { get; set; } = string.Empty;
        public int RefugioId { get; set; }
        public string NombreRefugio { get; set; } = string.Empty;
        public string DireccionRefugio { get; set; } = string.Empty;
        public string BarrioRefugio { get; set; } = string.Empty;
        public char GeneroAnimal { get; set; }
        public string? ImgAnimal { get; set; }
        public string? InfoRefugio { get; set; }
        public string? TxtResponsable { get; set; }
        public bool SnTurnos { get; set; }
        public string? LnkTurnos { get; set; }
        public bool SnSeguimiento { get; set; }
        public string? LnkSeguimiento { get; set; }
        public bool SnCalificarRefugio { get; set; }
        public string? LnkCalificarRefugio { get; set; }
        public bool SnPlanVacunacion { get; set; }
        public int VeterinariaId { get; set; }
    }
}
