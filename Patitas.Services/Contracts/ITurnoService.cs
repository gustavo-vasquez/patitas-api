using Patitas.Services.DTO.Turno;
using Patitas.Services.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Contracts
{
    public interface ITurnoService
    {
        Task<TurnoResponseDTO> GetTurnos(IIdentity? identity, RolTypes rol);
        Task<TurnoResponseDTO> GetTurnosRefugio(IIdentity? identity);
        Task CreateTurno(IIdentity? identity, TurnoCreateDTO turnoDTO);
    }
}
