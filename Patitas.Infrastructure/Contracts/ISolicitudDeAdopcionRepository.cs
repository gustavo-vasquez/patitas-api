using Patitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Contracts
{
    public interface ISolicitudDeAdopcionRepository : IRepository<SolicitudDeAdopcion, int>
    {
        Task<bool> AdoptantePuedeComentar(ClaimsIdentity? identity);
    }
}
