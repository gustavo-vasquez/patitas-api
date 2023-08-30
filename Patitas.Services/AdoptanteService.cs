using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Services.Contracts;
using Patitas.Services.DTO.Adoptante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    internal sealed class AdoptanteService : IAdoptanteService
    {
        private readonly IRepositoryManager _repositoryManager;
        public AdoptanteService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async Task<AdoptantePerfilCompletoDTO> GetPerfilDelAdoptante(int adoptanteId)
        {
            Usuario? usuario = await _repositoryManager.UsuarioRepository.GetByIdAsync(adoptanteId);
            Adoptante? adoptante = await _repositoryManager.AdoptanteRepository.GetByIdAsync(adoptanteId);

            if (usuario != null && adoptante != null)
            {
                return new AdoptantePerfilCompletoDTO()
                {
                    NombreUsuario = usuario.NombreUsuario,
                    Email = usuario.Email,
                    FotoDePerfil = usuario.FotoDePerfil,
                    Nombre = adoptante.Nombre,
                    Apellido = adoptante.Apellido,
                    FechaNacimiento = adoptante.FechaNacimiento,
                    DNI = adoptante.DNI,
                    FechaCreacion = usuario.FechaCreacion,
                    Direccion = usuario.Direccion,
                    Telefono = usuario.Telefono
                };
            }
            
            throw new ArgumentException("El usuario o perfil de adoptante no existe.");
        }
    }
}
