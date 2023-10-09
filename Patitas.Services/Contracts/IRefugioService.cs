using Patitas.Services.DTO.Refugio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Contracts
{
    public interface IRefugioService
    {
        Task<ExplorarRefugiosDTO> ExplorarRefugios();
        Task<RefugioInfoBasicaDTO> GetInformacionBasicaDelRefugio(int refugioId);
        Task<RefugioResponseDTO> GetAnimalesDelRefugio(int refugioId);
        Task<RefugioResponseDTO> GetComentariosDelRefugio(int refugioId);
        Task<RefugioResponseDTO> GetVeterinariasAsociadas(int refugioId);
        Task<RefugioResponseDTO> GetInformacionCompleta(int refugioId);
    }
}
