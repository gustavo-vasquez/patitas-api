using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Veterinaria
{
    public class ItemVacunaDelPlanDTO
    {
        public string NombreVacuna { get; set; } = string.Empty;
        public int NroDosisAAplicar { get; set; }
        public DateTime? FechaDeAplicacion { get; set; }
    }
}
