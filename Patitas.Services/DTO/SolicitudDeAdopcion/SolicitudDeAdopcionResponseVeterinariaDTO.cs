using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.SolicitudDeAdopcion
{
    public class SolicitudDeAdopcionResponseVeterinariaDTO
    {
        public IEnumerable<SolicitudDeAdopcionDTO> SolicitudesActuales { get; set; } = new List<SolicitudDeAdopcionDTO>();
        public IEnumerable<SolicitudDeAdopcionDTO> SolicitudesPasadas { get; set; } = new List<SolicitudDeAdopcionDTO>();
    }
}
