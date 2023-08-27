using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Services.Contracts;
using Patitas.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    internal sealed class AdopterService : IAdopterService
    {
        private readonly IRepositoryManager _repositoryManager;
        public AdopterService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
        public async Task<AdopterProfileInfoDTO> GetAdopterProfileInfo(int id)
        {
            Usuario? user = await _repositoryManager.UserRepository.GetByIdAsync(id);
            Adoptante? adopter = await _repositoryManager.AdopterRepository.GetByIdAsync(id);

            AdopterProfileInfoDTO profile = new AdopterProfileInfoDTO
            {
                NombreUsuario = user!.NombreUsuario,
                Email = user.Email,
                FotoDePerfil = user.FotoDePerfil,
                Nombre = adopter!.Nombre,
                Apellido = adopter.Apellido,
                FechaNacimiento = adopter.FechaNacimiento,
                DNI = adopter.DNI,
                FechaCreacion = user.FechaCreacion,
                Direccion = user.Direccion,
                Telefono = user.Telefono
            };

            return profile;
        }
    }
}
