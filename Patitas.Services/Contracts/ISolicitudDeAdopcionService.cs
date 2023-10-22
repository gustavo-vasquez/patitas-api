using Patitas.Domain.Entities;
using Patitas.Services.DTO.SolicitudDeAdopcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Contracts
{
    public interface ISolicitudDeAdopcionService
    {
        Task CreateSolicitud(SolicitudDeAdopcionRequestDTO formularioPreAdopcionDTO, ClaimsIdentity identity);
    }
}
