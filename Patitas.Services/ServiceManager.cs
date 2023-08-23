using Patitas.Infrastructure;
using Patitas.Infrastructure.Contracts;
using Patitas.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IAdopterService> _adopterService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager));
            _adopterService = new Lazy<IAdopterService>(() => new AdopterService(repositoryManager));
        }

        public IUserService UserService => _userService.Value;
        public IAdopterService AdopterService => _adopterService.Value;
    }
}
