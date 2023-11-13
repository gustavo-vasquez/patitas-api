using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    internal class TurnoRepository : Repository<Turno, int>, ITurnoRepository
    {
        public TurnoRepository(PatitasContext context) : base(context)
        {
        }
    }
}
