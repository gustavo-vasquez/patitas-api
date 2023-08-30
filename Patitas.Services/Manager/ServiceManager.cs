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
        private readonly Lazy<IAdoptanteService> _adoptanteService;
        private readonly Lazy<IRefugioService> _refugioService;
        private readonly Lazy<IVeterinariaService> _veterinariaService;
        private readonly Lazy<IComentarioService> _comentarioService;
        private readonly Lazy<IAnimalService> _animalService;

        public ServiceManager(IRepositoryManager repositoryManager, IOptions<TokenManagement> tokenManagement)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(repositoryManager, tokenManagement));
            _adoptanteService = new Lazy<IAdoptanteService>(() => new AdoptanteService(repositoryManager));
            _refugioService = new Lazy<IRefugioService>(() => new RefugioService(repositoryManager));
            _veterinariaService = new Lazy<IVeterinariaService>(() => new VeterinariaService(repositoryManager));
            _comentarioService = new Lazy<IComentarioService>(() => new ComentarioService(repositoryManager));
            _animalService = new Lazy<IAnimalService>(() => new AnimalService(repositoryManager));
        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IAdoptanteService AdoptanteService => _adoptanteService.Value;
        public IRefugioService RefugioService => _refugioService.Value;
        public IVeterinariaService VeterinariaService => _veterinariaService.Value;
        public IComentarioService ComentarioService => _comentarioService.Value;
        public IAnimalService AnimalService => _animalService.Value;
    }
}
