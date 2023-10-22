using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.SolicitudDeAdopcion
{
    public class SolicitudDeAdopcionRequestDTO
    {
        public FormularioPreAdopcionDTO FormularioPreAdopcionDTO { get; set; } = null!;
        public int AnimalId { get; set; }
        public int RefugioId { get; set; }
    }
}
