using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    internal class VacunaRepository : Repository<Vacuna, int>, IVacunaRepository
    {
        public VacunaRepository(PatitasContext context) : base(context)
        {
        }
    }
}
