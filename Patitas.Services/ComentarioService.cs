using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Infrastructure.Repositories.Manager;
using Patitas.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    internal class ComentarioService : IComentarioService
    {
        private readonly IRepositoryManager _repositoryManager;
        public ComentarioService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
    }
}
