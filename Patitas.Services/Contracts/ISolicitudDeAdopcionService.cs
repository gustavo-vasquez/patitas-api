using Patitas.Domain.Entities;
using Patitas.Services.DTO.SolicitudDeAdopcion;
using Patitas.Services.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Contracts
{
    public interface ISolicitudDeAdopcionService
    {
        Task CreateSolicitud(SolicitudDeAdopcionRequestDTO formularioPreAdopcionDTO, ClaimsIdentity identity);
        Task<SolicitudDeAdopcionResponseDTO> GetSolicitudes(IIdentity? identity, RolTypes rolDeUsuario);
        Task<SolicitudDeAdopcionResponseDTO> GetSolicitudesRefugio(IIdentity? identity);
        Task AprobarSolicitudDeAdopcion(IIdentity? identity, int solicitudId);
    }
}
