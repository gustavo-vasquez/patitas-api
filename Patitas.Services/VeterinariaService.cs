﻿using Patitas.Domain.Entities;
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

        public async Task<SolicitudDetalleVeterinariaResponseDTO> GetSolicitudDetalle(IIdentity? identity, int solicitudId)
        {
            // obtengo el id de la veterinaria logueada
            int veterinariaId = await _repositoryManager.UsuarioRepository.GetUserLoggedId(identity);
            List<ItemVacunaDelPlanDTO> itemsDelPlan = new List<ItemVacunaDelPlanDTO>();

            // obtengo el plan de vacunación asociado con la veterinaria y la solicitud
            PlanDeVacunacion? plan = await _repositoryManager.PlanDeVacunacionRepository
                .FindByAsync(p => p.Id_Veterinaria.Equals(veterinariaId) && p.Id_SolicitudDeAdopcion.Equals(solicitudId));

            if (plan is null)
                throw new DirectoryNotFoundException("Tu veterinaria no tiene asignada está solicitud.");

            // obtengo las vacunas acordadas del plan de vacunación
            IEnumerable<VacunaDelPlan> vacunasDelPlan = await _repositoryManager.VacunaDelPlanRepository
                .FindAllByAsync(v => v.Id_PlanDeVacunacion.Equals(plan.Id));

            if(vacunasDelPlan.Count() > 0)
            {
                foreach(VacunaDelPlan item in vacunasDelPlan)
                {
                    Vacuna? vacuna = await _repositoryManager.VacunaRepository.GetByIdAsync(item.Id_Vacuna);
                    itemsDelPlan.Add(new ItemVacunaDelPlanDTO()
                    {
                        NombreVacuna = vacuna!.Nombre,
                        NroDosisAAplicar = item.NroDosis,
                        FechaDeAplicacion = item.FechaDeAplicacion
                    });
                }
            }

            // obtengo el contenido de la solicitud y del animal
            SolicitudDeAdopcion? solicitud = await _repositoryManager.SolicitudDeAdopcionRepository
                .GetByIdAsync(plan.Id_SolicitudDeAdopcion, IncludeTypes.REFERENCE_TABLE_NAME, "Animal");

            if (solicitud is null)
                throw new DirectoryNotFoundException("La solicitud no fue encontrada.");

            Raza? raza = await _repositoryManager.RazaRepository.GetByIdAsync(solicitud.Animal.Id_Raza);

            return new SolicitudDetalleVeterinariaResponseDTO()
            {
                ExisteListaDeVacunas = vacunasDelPlan.Count() > 0,
                NombreAnimal = solicitud.Animal.Nombre,
                RazaAnimal = raza!.Nombre,
                GeneroAnimal = solicitud.Animal.Genero == 'M' ? "Macho" : "Hembra",
                ImgAnimal = solicitud.Animal.Fotografia,
                Id_Animal = solicitud.Animal.Id,
                Id_Especie = raza.Id_Especie,
                Id_Refugio = solicitud.Id_Refugio,
                ItemsVacunaDelPlan = itemsDelPlan
            };
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
