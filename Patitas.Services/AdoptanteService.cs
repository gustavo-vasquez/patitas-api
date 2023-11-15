using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Infrastructure.Enums;
using Patitas.Services.Contracts;
using Patitas.Services.DTO.Adoptante;
using Patitas.Services.DTO.Turno;
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

        public async Task<AdopcionDetalleResponseDTO> GetAdopcionDetalle(IIdentity? identity, int solicitudId)
        {
            try
            {
                // obtengo el id del adoptante del cuál quiero obtener las solicitudes
                int adoptanteId = await _repositoryManager.UsuarioRepository.GetUserLoggedId(identity);

                // obtengo la solicitud de adopción que corresponde verificando también el id del adoptante
                SolicitudDeAdopcion? solicitud = await _repositoryManager.SolicitudDeAdopcionRepository.FindByAsync(s => s.Id.Equals(solicitudId) && s.Id_Adoptante.Equals(adoptanteId));

                if (solicitud is null)
                    throw new ArgumentException("La solicitud de adopción no existe o no pertenece al adoptante.");

                // obtengo el animal involucrado en la solicitud
                Animal? animal = await _repositoryManager.AnimalRepository.GetByIdAsync(solicitud.Id_Animal, IncludeTypes.REFERENCE_TABLE_NAME, "Raza");

                Usuario? usuario = await _repositoryManager.UsuarioRepository.GetByIdAsync(solicitud.Id_Refugio, IncludeTypes.REFERENCE_TABLE_NAME, "Barrio");
                Refugio? refugio = await _repositoryManager.RefugioRepository.GetByIdAsync(solicitud.Id_Refugio);

                // verifico si existe al menos un turno, seguimiento y plan de vacunación para la solicitud indicada
                bool tieneTurnos = await _repositoryManager.TurnoRepository.ExistsAsync(
                    t => t.Id_Adoptante.Equals(adoptanteId) &&
                    t.Id_Refugio.Equals(refugio!.Id) &&
                    t.Id_SolicitudDeAdopcion.Equals(solicitud.Id));

                bool tieneSeguimientos = await _repositoryManager.SeguimientoRepository.ExistsAsync(seg => seg.Id_SolicitudDeAdopcion.Equals(solicitud.Id));
                bool tienePlanes = await _repositoryManager.PlanDeVacunacionRepository.ExistsAsync(plan => plan.Id_SolicitudDeAdopcion.Equals(solicitud.Id));

                return new AdopcionDetalleResponseDTO()
                {
                    NroSolicitud = solicitud.Id,
                    SnAprobada = solicitud.Aprobada,
                    FechaInicio = solicitud.FechaInicio.ToString("d"),
                    HoraInicio = solicitud.FechaInicio.ToString("t"),
                    AnimalId = animal!.Id,
                    NombreAnimal = animal.Nombre,
                    RazaAnimal = animal.Raza.Nombre,
                    GeneroAnimal = animal.Genero,
                    ImgAnimal = animal.Fotografia,
                    RefugioId = refugio!.Id,
                    NombreRefugio = refugio.Nombre,
                    DireccionRefugio = usuario!.Direccion!,
                    BarrioRefugio = usuario.Barrio.Nombre,
                    TxtResponsable = string.Join(" ", refugio!.NombreResponsable, refugio.ApellidoResponsable),
                    SnTurnos = tieneTurnos,
                    LnkTurnos = "/adoptantes/1/mis-turnos?refugio_id=1",
                    SnSeguimiento = tieneSeguimientos,
                    LnkSeguimiento = "/adoptantes/1/seguimientos?veterinaria_id=1",
                    SnCalificarRefugio = solicitud.FechaFinalizacion is not null,
                    LnkCalificarRefugio = "/refugios/1/comentarios",
                    SnPlanVacunacion = tienePlanes
                };
            }
            catch
            {
                throw new ArgumentException("Ocurrió un problema al consultar las solicitudes de adopción del adoptante.");
            }
        }

        public async Task<TurnoDetalleAdoptanteDTO> GetTurnoDetalle(IIdentity? identity, int turnoId)
        {
            // obtengo el id del adoptante que consulta el turno
            int adoptanteId = await _repositoryManager.UsuarioRepository.GetUserLoggedId(identity);

            Turno? turno = await _repositoryManager.TurnoRepository.GetByIdAsync(turnoId);

            if (turno is null)
                throw new ArgumentException("El turno solicitado no existe.");

            Refugio? refugio = await _repositoryManager.RefugioRepository.GetByIdAsync(turno.Id_Refugio);

            if (refugio is null)
                throw new ArgumentException("El refugio asociado al turno no existe.");

            return new TurnoDetalleAdoptanteDTO()
            {
                Id = turno.Id,
                FechaTurno = turno.FechaProgramada.ToString("d"),
                HoraTurno = turno.FechaProgramada.ToString("t"),
                SolicitudId = turno.Id_SolicitudDeAdopcion,
                RefugioId = refugio.Id,
                NombreRefugio = refugio.Nombre,
                Asistio = turno.Asistio,
                EstaActivo = turno.EstaActivo,
                EstaConfirmado = turno.EstaConfirmado,
                PorReprogramar = turno.PorReprogramar,
                MotivoDeReprogramacion = turno.MotivoDeReprogramacion
            };
        }

        public async Task ConfirmarMiTurno(IIdentity? identity, int turnoId)
        {
            try
            {
                int adoptanteId = await _repositoryManager.UsuarioRepository.GetUserLoggedId(identity);
                Turno? turno = await _repositoryManager.TurnoRepository.FindByAsync(t => t.Id.Equals(turnoId) && t.Id_Adoptante.Equals(adoptanteId));

                if (turno is null)
                    throw new ArgumentException("El turno no existe.");

                turno.EstaConfirmado = true;
                await _repositoryManager.TurnoRepository.UpdateAsync(turno);
            }
            catch
            {
                throw new ArgumentException("No se pudo confirmar el turno debido a un problema inesperado.");
            }
        }
    }
}
