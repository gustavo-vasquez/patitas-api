using Patitas.Services.DTO.Veterinaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Contracts
{
    public interface IVeterinariaService
    {
        Task<SolicitudDetalleVeterinariaResponseDTO> GetSolicitudDetalle(IIdentity? identity, int solicitudId);
        Task<IEnumerable<VacunaComboDTO>> GetVacunaCombo(int especieId);
        Task CreateNuevoPlanDeVacunacion(IIdentity? identity, IEnumerable<PlanDeVacunacionRequestDTO> planVacunacionDTO, int solicitudId);
    }
}
