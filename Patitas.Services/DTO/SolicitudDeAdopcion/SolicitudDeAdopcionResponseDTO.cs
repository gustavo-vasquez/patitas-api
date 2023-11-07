using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.SolicitudDeAdopcion
{
    public class SolicitudDeAdopcionResponseDTO
    {
        public IEnumerable<SolicitudDeAdopcionDTO> PendientesDeAprobacion { get; set; } = new List<SolicitudDeAdopcionDTO>();
        public IEnumerable<SolicitudDeAdopcionDTO> AdopcionesEnCurso { get; set; } = new List<SolicitudDeAdopcionDTO>();
        public IEnumerable<SolicitudDeAdopcionDTO> AdopcionesExitosas { get; set; } = new List<SolicitudDeAdopcionDTO>();
        public IEnumerable<SolicitudDeAdopcionDTO> AdopcionesCanceladas { get; set; } = new List<SolicitudDeAdopcionDTO>();
    }
}
