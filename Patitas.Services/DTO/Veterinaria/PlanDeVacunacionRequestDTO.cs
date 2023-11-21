using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Veterinaria
{
    public class PlanDeVacunacionRequestDTO
    {
        public string NombreVacuna { get; set; } = string.Empty;
        public byte NroDosisVacuna { get; set; }
    }
}
