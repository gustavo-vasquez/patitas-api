using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Services.Contracts;
using Patitas.Services.DTO.Barrio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    internal sealed class BarrioService : IBarrioService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BarrioService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<BarrioResponseDTO>> GetBarrios()
        {
            IEnumerable<Barrio> barrios = await _repositoryManager.BarrioRepository.GetAllAsync();
            List<BarrioResponseDTO> barriosDTO = new List<BarrioResponseDTO>();

            foreach(Barrio barrio in barrios)
            {
                barriosDTO.Add(
                    new BarrioResponseDTO()
                    {
                        Id = barrio.Id,
                        Nombre = barrio.Nombre
                    }
                );
            }

            return barriosDTO;
        }
    }
}
