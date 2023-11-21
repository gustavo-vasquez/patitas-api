using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Seguimiento
{
    public class SeguimientoResponseDTO
    {
        public IEnumerable<SeguimientoTarjetaDTO> CitasActivas { get; set; } = new List<SeguimientoTarjetaDTO>();
        public IEnumerable<SeguimientoTarjetaDTO> CitasPasadas { get; set; } = new List<SeguimientoTarjetaDTO>();
    }
}
