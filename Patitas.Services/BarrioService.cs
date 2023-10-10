using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    public class BarrioService : IBarrioService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BarrioService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<string>> GetBarrios()
        {
            List<string> listadoDeBarrios = new List<string>();
            IEnumerable<Barrio> barrios = await _repositoryManager.BarrioRepository.GetAllAsync();

            foreach(Barrio barrio in barrios)
            {
                listadoDeBarrios.Add(barrio.Nombre);
            }

            return listadoDeBarrios;
        }
    }
}
