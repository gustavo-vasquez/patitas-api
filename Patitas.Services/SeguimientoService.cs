using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Infrastructure.Enums;
using Patitas.Services.Contracts;
using Patitas.Services.DTO.Seguimiento;
using Patitas.Services.DTO.Turno;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    internal sealed class SeguimientoService : ISeguimientoService
    {
        private readonly IRepositoryManager _repositoryManager;

        public SeguimientoService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<SeguimientoCreateDTO> CargarInfoParaCita(IIdentity? identity, int solicitudId)
        {
            int veterinariaId = await _repositoryManager.UsuarioRepository.GetUserLoggedId(identity);
            SolicitudDeAdopcion? solicitud = await _repositoryManager.SolicitudDeAdopcionRepository
                .GetByIdAsync(solicitudId, IncludeTypes.REFERENCE_TABLE_NAME, "Adoptante");

            if (solicitud is null)
                throw new DirectoryNotFoundException("La solicitud no existe.");

            Usuario? usuarioAdoptante = await _repositoryManager.UsuarioRepository.GetByIdAsync(solicitud.Adoptante.Id);
            Animal? animal = await _repositoryManager.AnimalRepository.GetByIdAsync(solicitud.Id_Animal);

            if (usuarioAdoptante is null || animal is null)
                throw new DirectoryNotFoundException("El usuario o animal requerido no existe.");

            PlanDeVacunacion? plan = await _repositoryManager.PlanDeVacunacionRepository
                .FindByAsync(p => p.Id_SolicitudDeAdopcion.Equals(solicitudId) && p.Id_Veterinaria.Equals(veterinariaId));

            if (plan is null)
                throw new DirectoryNotFoundException("El plan no existe.");

            VacunaDelPlan? vacunaDelPlan = await _repositoryManager.VacunaDelPlanRepository
                .FindByAsync(vac => vac.Id_PlanDeVacunacion.Equals(plan.Id) && vac.FechaDeAplicacion == null);

            if (vacunaDelPlan is null)
                throw new DirectoryNotFoundException("No se encontró ninguna vacuna pendiente.");

            Vacuna? vacuna = await _repositoryManager.VacunaRepository.GetByIdAsync(vacunaDelPlan.Id_Vacuna);

            if (vacuna is null)
                throw new DirectoryNotFoundException("No se encontró la vacuna.");

            return new SeguimientoCreateDTO()
            {
                NombreVacuna = vacuna.Nombre,
                NroDosisAAplicar = vacunaDelPlan.NroDosis,
                NombreAdoptante = usuarioAdoptante.NombreUsuario,
                NombreAnimal = animal.Nombre,
                FotoAnimal = animal.Fotografia
            };
        }

        public async Task CreateCita(IIdentity? identity, SeguimientoCreateDTO seguimientoDTO)
        {
            try
            {
                // obtengo el id de la veterinaria que va a crear la cita
                int veterinariaId = await _repositoryManager.UsuarioRepository.GetUserLoggedId(identity);

                CultureInfo provider = CultureInfo.InvariantCulture; // cultura universal para la fecha
                DateTime fechaDelTurno = Convert.ToDateTime(seguimientoDTO.Fecha, provider);

                if (seguimientoDTO.Hora is not null && seguimientoDTO.Minuto is not null && seguimientoDTO.SolicitudDeAdopcionId is not null)
                {
                    // busco el plan de vacunación correspondiente
                    PlanDeVacunacion? plan = await _repositoryManager.PlanDeVacunacionRepository
                        .FindByAsync(p => p.Id_SolicitudDeAdopcion.Equals(seguimientoDTO.SolicitudDeAdopcionId) && p.Id_Veterinaria.Equals(veterinariaId));

                    if (plan is null)
                        throw new DirectoryNotFoundException("No se encontró el plan de vacunación asociado a esta solicitud.");

                    // obtengo el primer registro que indica que no se aplicó la vacuna (esa sería la vacuna a aplicar)
                    VacunaDelPlan? vacunaAAplicar = await _repositoryManager.VacunaDelPlanRepository
                        .FindByAsync(v => v.Id_PlanDeVacunacion.Equals(plan.Id) && v.FechaDeAplicacion == null);

                    if (vacunaAAplicar is null)
                        throw new DirectoryNotFoundException("No hay vacunas por aplicar. Es posible que no se hayan cargado correctamente o que la adopción está completa.");
                    
                    // genero la nueva cita
                    SeguimientoDeVacunacion nuevaCita = new SeguimientoDeVacunacion()
                    {
                        FechaAsignada = new DateTime(fechaDelTurno.Year, fechaDelTurno.Month, fechaDelTurno.Day, seguimientoDTO.Hora.Value, seguimientoDTO.Minuto.Value, 00),
                        EstaAplicada = false,
                        NroDosis = vacunaAAplicar.NroDosis,
                        EstaActivo = true,
                        PorReprogramar = false,
                        MotivoDeReprogramacion = string.Empty,
                        Id_SolicitudDeAdopcion = seguimientoDTO.SolicitudDeAdopcionId.Value,
                        Id_Vacuna = vacunaAAplicar.Id_Vacuna,
                        Id_Veterinaria = veterinariaId
                    };

                    await _repositoryManager.SeguimientoRepository.CreateAsync(nuevaCita);
                }
                else
                    throw new ArgumentException("Ha enviado datos no válidos para crear la cita para seguimiento.");
            }
            catch
            {
                throw;
            }
        }

        public async Task<SeguimientoResponseDTO> GetSeguimientosVeterinaria(IIdentity? identity)
        {
            // obtengo el id de la veterinaria logueada
            int veterinariaId = await _repositoryManager.UsuarioRepository.GetUserLoggedId(identity);

            // obtengo los seguimientos asociados a la veterinaria
            IEnumerable<SeguimientoDeVacunacion> seguimientos = await _repositoryManager.SeguimientoRepository
                .FindAllByAsync(seg => seg.Id_Veterinaria.Equals(veterinariaId));

            List<SeguimientoTarjetaDTO> citasActivas = new List<SeguimientoTarjetaDTO>();
            List<SeguimientoTarjetaDTO> citasPasadas = new List<SeguimientoTarjetaDTO>();

            foreach(SeguimientoDeVacunacion seguimiento in seguimientos)
            {
                SolicitudDeAdopcion? solicitud = await _repositoryManager.SolicitudDeAdopcionRepository
                    .GetByIdAsync(seguimiento.Id_SolicitudDeAdopcion);

                if (solicitud is null)
                    throw new ArgumentException("La solicitud asociada al seguimiento no existe.");

                Usuario? usuarioAdoptante = await _repositoryManager.UsuarioRepository.GetByIdAsync(solicitud.Id_Adoptante);

                if (usuarioAdoptante is null)
                    throw new ArgumentException("El adoptante asociado al seguimiento no existe.");

                SeguimientoTarjetaDTO citaDTO = this.MapSeguimientoEntityToDTO(seguimiento);
                citaDTO.NombreAdoptante = usuarioAdoptante.NombreUsuario;

                if (seguimiento.EstaActivo && seguimiento.FechaAsignada > DateTime.Now)
                    citasActivas.Add(citaDTO);
                else
                    citasPasadas.Add(citaDTO);
            }

            return new SeguimientoResponseDTO
            {
                CitasActivas = citasActivas,
                CitasPasadas = citasPasadas
            };
        }

        private SeguimientoTarjetaDTO MapSeguimientoEntityToDTO(SeguimientoDeVacunacion cita)
        {
            SeguimientoTarjetaDTO citaDTO = new SeguimientoTarjetaDTO();
            citaDTO.Id = cita.Id;
            citaDTO.FechaAsignada = cita.FechaAsignada.ToString("d");
            citaDTO.HoraAsignada = cita.FechaAsignada.ToString("t");
            citaDTO.EstaAplicada = cita.EstaAplicada;
            citaDTO.EstaVencido = DateTime.Now > cita.FechaAsignada;
            citaDTO.PorReprogramar = cita.PorReprogramar;
            citaDTO.EstaActivo = cita.EstaActivo;

            return citaDTO;
        }
    }
}
