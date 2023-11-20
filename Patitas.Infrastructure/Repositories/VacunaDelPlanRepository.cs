using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    internal class VacunaDelPlanRepository : Repository<VacunaDelPlan, int>, IVacunaDelPlanRepository
    {
        public VacunaDelPlanRepository(PatitasContext context) : base(context)
        {
        }
    }
}
