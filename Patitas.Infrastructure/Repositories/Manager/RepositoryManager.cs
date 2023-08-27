using Patitas.Infrastructure.Contracts;
using Patitas.Infrastructure.Contracts.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories.Manager
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IAdopterRepository> _adopterRepository;
        private readonly Lazy<INeighborhoodRepository> _neighborhoodRepository;
        private readonly Lazy<IRoleRepository> _roleRepository;

        public RepositoryManager(PatitasContext context)
        {
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
            _adopterRepository = new Lazy<IAdopterRepository>(() => new AdopterRepository(context));
            _neighborhoodRepository = new Lazy<INeighborhoodRepository>(() => new NeighborhoodRepository(context));
            _roleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(context));
        }

        public IUserRepository UserRepository => _userRepository.Value;
        public IAdopterRepository AdopterRepository => _adopterRepository.Value;
        public INeighborhoodRepository NeighborhoodRepository => _neighborhoodRepository.Value;
        public IRoleRepository RoleRepository => _roleRepository.Value;
    }
}
