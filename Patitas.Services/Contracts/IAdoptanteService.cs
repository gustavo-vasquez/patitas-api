using Patitas.Services.DTO.Adoptante;
using Patitas.Services.DTO.Turno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Contracts
{
    public interface IAdoptanteService
    {
        Task<AdoptantePerfilCompletoDTO> GetPerfilDelAdoptante(IIdentity? identity);
		Task<AdopcionDetalleResponseDTO> GetAdopcionDetalle(IIdentity? identity, int solicitudId);
        Task<TurnoDetalleAdoptanteDTO> GetTurnoDetalle(IIdentity? identity, int turnoId);
        Task ConfirmarMiTurno(IIdentity? identity, int turnoId);
        Task CrearComentario(IIdentity? identity, ComentarioCreateDTO comentarioDTO);
    }
}
