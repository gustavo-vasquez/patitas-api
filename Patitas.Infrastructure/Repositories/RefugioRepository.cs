using Microsoft.EntityFrameworkCore;
using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    internal class RefugioRepository : Repository<Refugio, int>, IRefugioRepository
    {
        private readonly PatitasContext _context;

        public RefugioRepository(PatitasContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> GetVeterinariasHabilitadas(int refugioId)
        {
            // obtengo veterinarias asociadas a el refugio elegido
            List<VeterinariaAsignadaARefugio> veterinariasAsignadas = await _context.VeterinariasAsignadasARefugios
                .Where(var => var.Id_Refugio.Equals(refugioId)).ToListAsync();

            List<string> nombresDeVeterinarias = new List<string>();

            foreach(VeterinariaAsignadaARefugio veterinariaAsignadaARefugio in veterinariasAsignadas)
            {
                Veterinaria? veterinaria = await _context.Veterinarias.FindAsync(veterinariaAsignadaARefugio.Id_Veterinaria);

                if (veterinaria is not null)
                    nombresDeVeterinarias.Add(veterinaria.Nombre);
            }

            return nombresDeVeterinarias;
        }

        public async Task<bool> AdoptanteTieneComentario(ClaimsIdentity? identity, int refugioId)
        {
            try
            {
                if (identity != null && identity.IsAuthenticated)
                {
                    int id = Convert.ToInt32(identity.FindFirst(ClaimTypes.NameIdentifier)?.Value); // obtengo el id del usuario que estaba en el token
                    string? email = identity.FindFirst(ClaimTypes.Email)?.Value; // obtengo el email del usuario que estaba en el token
                    string? rol = identity.FindFirst(ClaimTypes.Role)?.Value; // obtengo el rol del usuario logueado

                    if (rol == "Adoptante")
                    {
                        // utilizo el id y el email para recuperar el usuario
                        Usuario? usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id.Equals(id) && u.Email.Equals(email));

                        if (usuario is not null)
                        {
                            return await _context.Comentarios.AnyAsync(c => c.Id_Adoptante.Equals(id) && c.Id_Refugio.Equals(refugioId));
                        }

                        return false;
                    }
                }

                return false;
            }
            catch
            {
                throw new ArgumentException("Ocurrió un error al comprobar si el adoptante tiene algún comentario.");
            }
        }
    }
}
