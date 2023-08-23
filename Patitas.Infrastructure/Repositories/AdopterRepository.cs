using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    internal class AdopterRepository : Repository<Adoptante, int>, IAdopterRepository
    {
        private readonly PatitasContext _context;
        public AdopterRepository(PatitasContext context) : base(context)
        {
            _context = context;
        }

        public Task<FormularioPreAdopcion> GetPreAdoptionForm(int id)
        {
            throw new NotImplementedException();
        }
    }
}
