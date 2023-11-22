using Patitas.Services.DTO.Seguimiento;
using Patitas.Services.DTO.Turno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Contracts
{
    public interface ISeguimientoService
    {
        Task<SeguimientoResponseDTO> GetSeguimientosVeterinaria(IIdentity? identity);
        Task CreateCita(IIdentity? identity, SeguimientoCreateDTO seguimientoDTO);
        Task<SeguimientoCreateDTO> CargarInfoParaCita(IIdentity? identity, int solicitudId);
    }
}
