using Microsoft.EntityFrameworkCore;
using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    internal class SolicitudDeAdopcionRepository : Repository<SolicitudDeAdopcion, int>, ISolicitudDeAdopcionRepository
    {
        private readonly PatitasContext _context;

        public SolicitudDeAdopcionRepository(PatitasContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AdoptantePuedeComentar(ClaimsIdentity? identity)
        {
            try
            {
                if (identity != null && identity.IsAuthenticated)
                {
                    int id = Convert.ToInt32(identity.FindFirst(ClaimTypes.NameIdentifier)?.Value); // obtengo el id del usuario que estaba en el token
                    string? email = identity.FindFirst(ClaimTypes.Email)?.Value; // obtengo el email del usuario que estaba en el token

                    // utilizo el id y el email para recuperar el usuario
                    Usuario? usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id.Equals(id) && u.Email.Equals(email));

                    if (usuario is not null)
                    {
                        // pregunto si existe alguna solicitud de adopción que el usuario haya finalizado
                        return await _context.SolicitudesDeAdopcion
                            .AnyAsync(s => s.Id_Adoptante.Equals(usuario.Id) && s.FechaFinalizacion != null);
                    }

                    return false;
                }

                return false;
            }
            catch
            {
                throw new ArgumentException("Ocurrió un error al comprobar si el adoptante completó alguna adopción.");
            }
        }
    }
}
