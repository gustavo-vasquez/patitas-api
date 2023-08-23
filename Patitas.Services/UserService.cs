using Patitas.Infrastructure.Contracts;
using Patitas.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    }
}
