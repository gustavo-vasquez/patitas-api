using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    internal class ComentarioRepository : Repository<Comentario, int>, IComentarioRepository
    {
        private readonly PatitasContext _context;

        public ComentarioRepository(PatitasContext context) : base(context)
        {
            _context = context;
        }
    }
}
