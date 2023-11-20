using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Veterinaria
{
    public class VacunaComboDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int NroDosis { get; set; }
        public string EdadIndicada { get; set; } = string.Empty;
    }
}
