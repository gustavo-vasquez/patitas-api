using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    internal class SeguimientoRepository : Repository<SeguimientoDeVacunacion, int>, ISeguimientoRepository
    {
        public SeguimientoRepository(PatitasContext context) : base(context)
        {
        }
    }
}
