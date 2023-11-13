using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    internal class CancelacionDeAdopcionRepository : Repository<CancelacionDeAdopcion, int>, ICancelacionDeAdopcionRepository
    {
        public CancelacionDeAdopcionRepository(PatitasContext context) : base(context)
        {
        }
    }
}
