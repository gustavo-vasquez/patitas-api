using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Services.Contracts;
using Patitas.Services.DTO.Adoptante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    internal sealed class AdoptanteService : IAdoptanteService
    {
        private readonly IRepositoryManager _repositoryManager;
        public AdoptanteService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async Task<AdoptantePerfilCompletoDTO> GetPerfilDelAdoptante(IIdentity? identity)
        {
            // verifico si el usuario es válido
            if (identity is null || !identity.IsAuthenticated)
                throw new UnauthorizedAccessException("No tiene los permisos para ver esta sección.");

            // obtengo el id del usuario que estaba en el token
            ClaimsIdentity? claimsIdentity = identity as ClaimsIdentity;
            int adoptanteId = Convert.ToInt32(claimsIdentity!.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            Usuario? usuario = await _repositoryManager.UsuarioRepository.GetByIdAsync(adoptanteId, Infrastructure.Enums.IncludeTypes.REFERENCE_TABLE_NAME, "Barrio");
            Adoptante? adoptante = await _repositoryManager.AdoptanteRepository.GetByIdAsync(adoptanteId);

            IEnumerable<SolicitudDeAdopcion> solicitudes = await _repositoryManager.SolicitudDeAdopcionRepository.FindAllByAsync(s => s.Id_Adoptante.Equals(adoptanteId) && s.FechaFinalizacion != null);

            if (usuario is not null && adoptante is not null)
            {
                return new AdoptantePerfilCompletoDTO()
                {
                    NombreUsuario = usuario.NombreUsuario,
                    Email = usuario.Email,
                    FotoDePerfil = usuario.FotoDePerfil,
                    Nombre = adoptante.Nombre,
                    Apellido = adoptante.Apellido,
                    FechaNacimiento = adoptante.FechaNacimiento.HasValue ? adoptante.FechaNacimiento.Value.ToString("d") : null,
                    DNI = adoptante.DNI,
                    FechaCreacion = usuario.FechaCreacion.ToString("g"),
                    NombreBarrio = usuario.Barrio.Nombre,
                    Direccion = usuario.Direccion,
                    Telefono = usuario.Telefono,
                    CantidadAdopcionesExitosas = solicitudes.Count(),
                    CantidadAdopcionesFalladas = 0
                };
            }
            
            throw new ArgumentException("El usuario o perfil de adoptante no existe.");
        }
    }
}
