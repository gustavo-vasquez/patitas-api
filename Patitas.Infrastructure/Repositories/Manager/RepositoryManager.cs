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
        private readonly Lazy<IUsuarioRepository> _usuarioRepository;
        private readonly Lazy<IAdoptanteRepository> _adoptanteRepository;
        private readonly Lazy<IRefugioRepository> _refugioRepository;
        private readonly Lazy<IVeterinariaRepository> _veterinariaRepository;
        private readonly Lazy<IBarrioRepository> _barrioRepository;
        private readonly Lazy<IRolRepository> _rolRepository;
        private readonly Lazy<IComentarioRepository> _comentarioRepository;
        private readonly Lazy<IAnimalRepository> _animalRepository;

        public RepositoryManager(PatitasContext context)
        {
            _usuarioRepository = new Lazy<IUsuarioRepository>(() => new UsuarioRepository(context));
            _adoptanteRepository = new Lazy<IAdoptanteRepository>(() => new AdoptanteRepository(context));
            _refugioRepository = new Lazy<IRefugioRepository>(() => new RefugioRepository(context));
            _veterinariaRepository = new Lazy<IVeterinariaRepository>(() => new VeterinariaRepository(context));
            _barrioRepository = new Lazy<IBarrioRepository>(() => new BarrioRepository(context));
            _rolRepository = new Lazy<IRolRepository>(() => new RolRepository(context));
            _comentarioRepository = new Lazy<IComentarioRepository>(() => new ComentarioRepository(context));
            _animalRepository = new Lazy<IAnimalRepository>(() => new AnimalRepository(context));
        }

        public IUsuarioRepository UsuarioRepository => _usuarioRepository.Value;
        public IAdoptanteRepository AdoptanteRepository => _adoptanteRepository.Value;
        public IRefugioRepository RefugioRepository => _refugioRepository.Value;
        public IVeterinariaRepository VeterinariaRepository => _veterinariaRepository.Value;
        public IBarrioRepository BarrioRepository => _barrioRepository.Value;
        public IRolRepository RolRepository => _rolRepository.Value;
        public IComentarioRepository ComentarioRepository => _comentarioRepository.Value;
        public IAnimalRepository AnimalRepository => _animalRepository.Value;
    }
}
