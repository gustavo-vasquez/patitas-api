using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Turno
{
    public class TurnoResponseDTO
    {
        public List<TurnoTarjetaDTO> TurnosActivos { get; set; } = new List<TurnoTarjetaDTO>();
        public List<TurnoTarjetaDTO> TurnosPasados { get; set; } = new List<TurnoTarjetaDTO>();
        public List<FiltroRefugiosDTO> FiltroRefugios { get; set; } = new List<FiltroRefugiosDTO>();
    }
}
