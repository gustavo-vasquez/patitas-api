using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Veterinaria
{
    public class SolicitudDetalleVeterinariaResponseDTO
    {
        public bool ExisteListaDeVacunas { get; set; }
        public string NombreAnimal { get; set; } = string.Empty;
        public string RazaAnimal { get; set;} = string.Empty;
        public string GeneroAnimal { get; set; } = string.Empty;
        public string ImgAnimal { get; set; } = string.Empty;
        public int Id_Animal { get; set; }
        public int Id_Especie { get; set; }
        public int Id_Refugio { get; set; }
        public List<ItemVacunaDelPlanDTO> ItemsVacunaDelPlan { get; set; } = new List<ItemVacunaDelPlanDTO>();
    }
}
