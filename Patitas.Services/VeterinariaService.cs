using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Infrastructure.Enums;
using Patitas.Services.Contracts;
using Patitas.Services.DTO.Veterinaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    internal sealed class VeterinariaService : IVeterinariaService
    {
        private readonly IRepositoryManager _repositoryManager;

        public VeterinariaService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<VacunaComboDTO>> GetVacunaCombo(int especieId)
        {
            try
            {
                Especie? especie = await _repositoryManager.EspecieRepository
                    .GetByIdAsync(especieId, IncludeTypes.COLLECTION_TABLE_NAME, "Vacunas");

                if (especie is null)
                    throw new DirectoryNotFoundException("No se encontró la especie solicitada.");

                List<VacunaComboDTO> vacunaCombo = new List<VacunaComboDTO>();

                foreach(Vacuna vacuna in especie.Vacunas)
                {
                    vacunaCombo.Add(new VacunaComboDTO()
                    {
                        Id = vacuna.Id,
                        Nombre = vacuna.Nombre,
                        NroDosis = vacuna.CantidadDeDosis,
                        EdadIndicada = vacuna.EdadIndicada,
                    });
                }

                return vacunaCombo;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateNuevoPlanDeVacunacion(IIdentity? identity, IEnumerable<PlanDeVacunacionRequestDTO> vacunasDelPlan, int solicitudId)
        {
            // obtengo el id de la veterinaria logueada
            int veterinariaId = await _repositoryManager.UsuarioRepository.GetUserLoggedId(identity);

            // busco el plan de vacunación correspondiente a la veterinaria y a la solicitud
            PlanDeVacunacion? planDeVacunacion = await _repositoryManager.PlanDeVacunacionRepository
                .FindByAsync(plan => plan.Id_Veterinaria.Equals(veterinariaId) && plan.Id_SolicitudDeAdopcion.Equals(solicitudId));

            if (planDeVacunacion is null)
                throw new ArgumentException("No se pudo crear el plan de vacunación.");

            foreach(PlanDeVacunacionRequestDTO item in vacunasDelPlan)
            {
                // si el nombre de la vacuna existe, devuelvo los datos de esa vacuna
                Vacuna? vacuna = await _repositoryManager.VacunaRepository.FindByAsync(v => v.Nombre.Equals(item.NombreVacuna));

                if (vacuna is null)
                    throw new DirectoryNotFoundException("La vacuna enviada no existe.");

                VacunaDelPlan nuevoItem = new VacunaDelPlan()
                {
                    Id_PlanDeVacunacion = planDeVacunacion.Id,
                    Id_Vacuna = vacuna.Id,
                    NroDosis = item.NroDosisVacuna
                };

                await _repositoryManager.VacunaDelPlanRepository.CreateAsync(nuevoItem);
            }

        }
    }
}
