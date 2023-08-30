using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    internal class VeterinariaService : IVeterinariaService
    {
        private readonly IRepositoryManager _repositoryManager;

        public VeterinariaService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
    }
}
