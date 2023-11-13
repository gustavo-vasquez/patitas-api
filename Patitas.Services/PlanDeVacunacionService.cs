using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    internal sealed class PlanDeVacunacionService : IPlanDeVacunacionService
    {
        private readonly IRepositoryManager _repositoryManager;

        public PlanDeVacunacionService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
    }
}
