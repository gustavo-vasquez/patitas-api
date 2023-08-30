using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    internal class AdoptanteRepository : Repository<Adoptante, int>, IAdoptanteRepository
    {
        private readonly PatitasContext _context;
        public AdoptanteRepository(PatitasContext context) : base(context)
        {
            _context = context;
        }
    }
}
