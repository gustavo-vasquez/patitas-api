using Patitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Contracts
{
    public interface IAdopterRepository : IRepository<Adoptante, int>
    {
        Task<FormularioPreAdopcion> GetPreAdoptionForm(int id);
    }
}
