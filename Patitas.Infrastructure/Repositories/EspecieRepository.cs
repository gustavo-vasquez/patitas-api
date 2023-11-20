using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    internal class EspecieRepository : Repository<Especie, int>, IEspecieRepository
    {
        public EspecieRepository(PatitasContext context) : base(context)
        {
        }
    }
}
