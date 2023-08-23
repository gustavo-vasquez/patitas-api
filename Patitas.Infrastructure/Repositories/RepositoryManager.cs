using Patitas.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IAdopterRepository> _adopterRepository;

        public RepositoryManager(PatitasContext context)
        {
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
            _adopterRepository = new Lazy<IAdopterRepository>(() => new AdopterRepository(context));
        }

        public IUserRepository UserRepository => _userRepository.Value;
        public IAdopterRepository AdopterRepository => _adopterRepository.Value;
    }
}
