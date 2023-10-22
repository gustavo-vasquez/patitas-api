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
        private readonly Lazy<IDetalleEstrellaRepository> _detalleEstrellaRepository;
        private readonly Lazy<ISolicitudDeAdopcionRepository> _solicitudDeAdopcionRepository;
        private readonly Lazy<IRazaRepository> _razaRepository;
        private readonly Lazy<IFormularioPreAdopcionRepository> _formularioPreAdopcionRepository;

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
            _detalleEstrellaRepository = new Lazy<IDetalleEstrellaRepository>(() => new DetalleEstrellaRepository(context));
            _solicitudDeAdopcionRepository = new Lazy<ISolicitudDeAdopcionRepository>(() => new SolicitudDeAdopcionRepository(context));
            _razaRepository = new Lazy<IRazaRepository>(() => new RazaRepository(context));
            _formularioPreAdopcionRepository = new Lazy<IFormularioPreAdopcionRepository>(() => new FormularioPreAdopcionRepository(context));
        }

        public IUsuarioRepository UsuarioRepository => _usuarioRepository.Value;
        public IAdoptanteRepository AdoptanteRepository => _adoptanteRepository.Value;
        public IRefugioRepository RefugioRepository => _refugioRepository.Value;
        public IVeterinariaRepository VeterinariaRepository => _veterinariaRepository.Value;
        public IBarrioRepository BarrioRepository => _barrioRepository.Value;
        public IRolRepository RolRepository => _rolRepository.Value;
        public IComentarioRepository ComentarioRepository => _comentarioRepository.Value;
        public IAnimalRepository AnimalRepository => _animalRepository.Value;
        public IDetalleEstrellaRepository DetalleEstrellaRepository => _detalleEstrellaRepository.Value;
        public ISolicitudDeAdopcionRepository SolicitudDeAdopcionRepository => _solicitudDeAdopcionRepository.Value;
        public IRazaRepository RazaRepository => _razaRepository.Value;
        public IFormularioPreAdopcionRepository FormularioPreAdopcionRepository => _formularioPreAdopcionRepository.Value;
    }
}
