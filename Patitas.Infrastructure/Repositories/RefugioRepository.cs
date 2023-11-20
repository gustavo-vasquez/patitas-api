using Microsoft.EntityFrameworkCore;
using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    }
}
