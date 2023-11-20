using Patitas.Services.DTO.Refugio;
using Patitas.Services.DTO.Turno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Contracts
{
    public interface IRefugioService
    {
        Task<ExplorarRefugiosDTO> ExplorarRefugios();
        Task<IEnumerable<RefugioDTO>> BuscarRefugios(string? nombre, string? barrio);
        Task<RefugioInfoBasicaDTO> GetInformacionBasicaDelRefugio(int refugioId);
        Task<RefugioResponseDTO> GetAnimalesDelRefugio(int refugioId, ClaimsIdentity? identity);
        Task<AnimalDelRefugioDTO> GetAnimalDelRefugio(int animalId, ClaimsIdentity? identity);
        Task<RefugioResponseDTO> GetComentariosDelRefugio(int refugioId, ClaimsIdentity? identity);
        Task<RefugioResponseDTO> GetVeterinariasAsociadas(int refugioId);
        Task<RefugioResponseDTO> GetInformacionCompleta(int refugioId);
        Task<RefugioPerfilCompletoDTO> GetPerfilDelRefugio(IIdentity? identity);
        Task<SolicitudDetalleResponseDTO> GetSolicitudDetalle(IIdentity? identity, int solicitudId);
        Task<TurnoDetalleRefugioDTO> GetTurnoDetalle(IIdentity? identity, int turnoId);
        Task MarcarAsistenciaDeTurno(IIdentity? identity, TurnoMarcarAsistenciaDTO marcarAsistenciaDTO);
        Task<IEnumerable<string>> GetVeterinariasHabilitadas(int refugioId);
    }
}
