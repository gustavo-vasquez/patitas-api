using Microsoft.Extensions.Options;
using Patitas.Infrastructure;
using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Services.Contracts;
using Patitas.Services.Contracts.Manager;
using Patitas.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Manager
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IAdopterService> _adopterService;

        public ServiceManager(IRepositoryManager repositoryManager, IOptions<TokenManagement> tokenManagement)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(repositoryManager, tokenManagement));
            _adopterService = new Lazy<IAdopterService>(() => new AdopterService(repositoryManager));
        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IAdopterService AdopterService => _adopterService.Value;
    }
}
