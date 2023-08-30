using Microsoft.EntityFrameworkCore;
using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
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
    }
}
