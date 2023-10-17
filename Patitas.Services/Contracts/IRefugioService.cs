using Patitas.Services.DTO.Refugio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Contracts
{
    public interface IRefugioService
    {
        Task<ExplorarRefugiosDTO> ExplorarRefugios();
        Task<IEnumerable<RefugioDTO>> BuscarRefugios(string? nombre, string? barrio);
        Task<RefugioInfoBasicaDTO> GetInformacionBasicaDelRefugio(int refugioId);
        Task<RefugioResponseDTO> GetAnimalesDelRefugio(int refugioId);
        Task<RefugioResponseDTO> GetComentariosDelRefugio(int refugioId, ClaimsIdentity? identity);
        Task<RefugioResponseDTO> GetVeterinariasAsociadas(int refugioId);
        Task<RefugioResponseDTO> GetInformacionCompleta(int refugioId);
    }
}
