using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    internal class RazaRepository : Repository<Raza, int>, IRazaRepository
    {
        private readonly PatitasContext _context;

        public RazaRepository(PatitasContext context) : base(context)
        {
            _context = context;
        }
    }
}
