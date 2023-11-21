using Microsoft.AspNetCore.Http;
using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Infrastructure.Enums;
using Patitas.Services.Contracts;
using Patitas.Services.DTO.SolicitudDeAdopcion;
using Patitas.Services.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    internal sealed class SolicitudDeAdopcionService : ISolicitudDeAdopcionService
    {
        private readonly IRepositoryManager _repositoryManager;

        public SolicitudDeAdopcionService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task CreateSolicitud(SolicitudDeAdopcionRequestDTO solicitudDeAdopcionRequestDTO, ClaimsIdentity identity)
        {
            try
            {
                // obtengo el id del usuario que estaba en el token
                int adoptanteId = Convert.ToInt32(identity.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                // creo la solicitud de adopción
                SolicitudDeAdopcion nuevaSolicitud = new SolicitudDeAdopcion
                {
                    FechaInicio = DateTime.Now,
                    Aprobada = false,
                    EstaActivo = true,
                    Id_Adoptante = adoptanteId,
                    Id_Animal = solicitudDeAdopcionRequestDTO.AnimalId,
                    Id_Refugio = solicitudDeAdopcionRequestDTO.RefugioId
                };

                await _repositoryManager.SolicitudDeAdopcionRepository.CreateAsync(nuevaSolicitud);

                FormularioPreAdopcion nuevoFormulario = new FormularioPreAdopcion();
                nuevoFormulario.Id_Adoptante = adoptanteId;
                nuevoFormulario.Id_SolicitudDeAdopcion = nuevaSolicitud.Id;
                nuevoFormulario.Motivo = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.Motivo;
                nuevoFormulario.TuvoMascota = Convert.ToBoolean(solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TuvoMascota);
                nuevoFormulario.TieneMascotas = Convert.ToBoolean(solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TieneMascotas);
                nuevoFormulario.DescripcionMascotas = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.DescripcionMascotas;
                nuevoFormulario.ViveSolo = Convert.ToBoolean(solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.ViveSolo);
                nuevoFormulario.TieneVeterinariaCerca = Convert.ToBoolean(solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TieneVeterinariaCerca);
                nuevoFormulario.ViveEnCasa = Convert.ToBoolean(solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.ViveEnCasa);
                nuevoFormulario.ViveEnDepartamento = !nuevoFormulario.ViveEnCasa;
                nuevoFormulario.CantidadDeAmbientes = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.CantidadDeAmbientes ?? 0;
                nuevoFormulario.TienePatio = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.HogarTiene.Contains("patio");
                nuevoFormulario.TieneBalcon = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.HogarTiene.Contains("balcon");
                nuevoFormulario.TieneRedEnVentanas = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.HogarTiene.Contains("redes");
                nuevoFormulario.ConoceLeyDeMaltratoAnimal = Convert.ToBoolean(solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.ConoceLeyDeMaltratoAnimal);
                nuevoFormulario.FrecuenciaAnimalSolo = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.FrecuenciaAnimalSolo!;
                nuevoFormulario.TieneConocidosEnCasoDeEmergencia = Convert.ToBoolean(solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TieneConocidosEnCasoDeEmergencia);
                nuevoFormulario.TieneSalarioAcordeAGastos = Convert.ToBoolean(solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TieneSalarioAcordeAGastos);
                nuevoFormulario.TieneConocidosQueLoAconsejen = Convert.ToBoolean(solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TieneConocidosQueLoAconsejen);

                // creo el formulario de pre-adopción
                await _repositoryManager.FormularioPreAdopcionRepository.CreateAsync(nuevoFormulario);
            }
            catch
            {
                throw new Exception("Ocurrió un problema al crear la solicitud de adopción.");
            }
        }

        public async Task<SolicitudDeAdopcionResponseDTO> GetSolicitudes(IIdentity? identity, RolTypes rolDeUsuario)
        {
            // verifico si el usuario es válido
            if (identity is null || !identity.IsAuthenticated)
                throw new UnauthorizedAccessException("No tiene los permisos para ver las solicitudes de adopción.");

            // obtengo el id del usuario que estaba en el token
            ClaimsIdentity? claimsIdentity = identity as ClaimsIdentity;
            int userLoggedId = Convert.ToInt32(claimsIdentity!.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (!await _repositoryManager.UsuarioRepository.ExistsAsync(u => u.Id.Equals(userLoggedId)))
                throw new ArgumentException("El usuario logueado no existe.");

            // obtengo todas las solicitudes de adopción del adoptante
            IEnumerable<SolicitudDeAdopcion> solicitudes = await _repositoryManager.SolicitudDeAdopcionRepository.FindAllByAsync(s => s.Id_Adoptante.Equals(userLoggedId));

            // inicializo las listas de los tipos de solicitudes que voy a mostrar en el panel "mis solicitudes"
            List<SolicitudDeAdopcionDTO> pendientesDeAprobacion = new List<SolicitudDeAdopcionDTO>();
            List<SolicitudDeAdopcionDTO> adopcionesEnCurso = new List<SolicitudDeAdopcionDTO>();
            List<SolicitudDeAdopcionDTO> adopcionesExitosas = new List<SolicitudDeAdopcionDTO>();
            List<SolicitudDeAdopcionDTO> adopcionesCanceladas = new List<SolicitudDeAdopcionDTO>();

            foreach (SolicitudDeAdopcion solicitud in solicitudes)
            {
                // obtengo el usuario asociado al refugio
                Usuario? usuarioRefugio = await _repositoryManager.UsuarioRepository.GetByIdAsync(solicitud.Id_Refugio, Infrastructure.Enums.IncludeTypes.REFERENCE_TABLE_NAME, "Barrio");
                // obtengo el refugio asociado
                Refugio? refugio = await _repositoryManager.RefugioRepository.GetByIdAsync(solicitud.Id_Refugio);

                if (usuarioRefugio is null || refugio is null)
                    throw new ArgumentNullException($"El refugio de la solicitud Nº {solicitud.Id} no existe.");

                // obtengo el barrio y el animal a mostrar
                //Barrio? barrio = await _repositoryManager.BarrioRepository.GetByIdAsync(usuarioRefugio.Id_Barrio);
                Animal? animal = await _repositoryManager.AnimalRepository.GetByIdAsync(solicitud.Id_Animal);

                SolicitudDeAdopcionDTO solicitudDTO = this.MapSolicitudEntityToDTO(solicitud);
                solicitudDTO.Nombre = refugio.Nombre;
                solicitudDTO.Ubicacion = string.Join(", ", usuarioRefugio.Direccion, usuarioRefugio.Barrio.Nombre);
                solicitudDTO.NombreAnimal = animal!.Nombre;
                solicitudDTO.FotoAnimal = animal.Fotografia;

                if (solicitud.FechaFinalizacion is not null)
                    adopcionesExitosas.Add(solicitudDTO);
                else if (solicitud.EstaActivo && !solicitud.Aprobada)
                    pendientesDeAprobacion.Add(solicitudDTO);
                else if (solicitud.EstaActivo && solicitud.Aprobada)
                {
                    // verifico si tiene al menos un turno
                    bool existeAlgunTurno;
                    if (!solicitudDTO.EnEtapaDeSeguimiento)
                    {
                        existeAlgunTurno = await _repositoryManager.TurnoRepository
                        .ExistsAsync(t => t.Id_SolicitudDeAdopcion.Equals(solicitud.Id) && t.EstaActivo);
                    }
                    else
                    {
                        existeAlgunTurno = await _repositoryManager.SeguimientoRepository
                        .ExistsAsync(seg => seg.Id_SolicitudDeAdopcion.Equals(solicitud.Id) && seg.EstaActivo);
                    }
                    solicitudDTO.ExisteAlgunTurno = existeAlgunTurno;
                    adopcionesEnCurso.Add(solicitudDTO);
                }
                else
                {
                    // obtengo la fecha y hora de cancelación de la adopción
                    CancelacionDeAdopcion? adopcionCancelada = await _repositoryManager.CancelacionDeAdopcionRepository.FindByAsync(ca => ca.Id_Solicitud.Equals(solicitud.Id));
                    solicitudDTO.FechaCancelacion = adopcionCancelada!.FechaDeCancelacion.ToString("d");
                    solicitudDTO.HoraCancelacion = adopcionCancelada!.FechaDeCancelacion.ToString("t");
                    adopcionesCanceladas.Add(solicitudDTO);
                }
            }

            return new SolicitudDeAdopcionResponseDTO()
            {
                PendientesDeAprobacion = pendientesDeAprobacion,
                AdopcionesEnCurso = adopcionesEnCurso,
                AdopcionesExitosas = adopcionesExitosas,
                AdopcionesCanceladas = adopcionesCanceladas
            };
        }

        public async Task<SolicitudDeAdopcionResponseDTO> GetSolicitudesRefugio(IIdentity? identity)
        {
            // verifico si el usuario es válido
            if (identity is null || !identity.IsAuthenticated)
                throw new UnauthorizedAccessException("No tiene los permisos para ver las solicitudes de adopción.");

            // obtengo el id del usuario que estaba en el token
            ClaimsIdentity? claimsIdentity = identity as ClaimsIdentity;
            int userLoggedId = Convert.ToInt32(claimsIdentity!.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (!await _repositoryManager.UsuarioRepository.ExistsAsync(u => u.Id.Equals(userLoggedId)))
                throw new ArgumentException("El usuario logueado no existe.");

            // obtengo todas las solicitudes de adopción que le pertenecen al refugio
            IEnumerable<SolicitudDeAdopcion> solicitudes = await _repositoryManager.SolicitudDeAdopcionRepository.FindAllByAsync(s => s.Id_Refugio.Equals(userLoggedId));

            // inicializo las listas de los tipos de solicitudes que voy a mostrar en el panel "mis solicitudes"
            List<SolicitudDeAdopcionDTO> pendientesDeAprobacion = new List<SolicitudDeAdopcionDTO>();
            List<SolicitudDeAdopcionDTO> adopcionesEnCurso = new List<SolicitudDeAdopcionDTO>();
            List<SolicitudDeAdopcionDTO> adopcionesExitosas = new List<SolicitudDeAdopcionDTO>();
            List<SolicitudDeAdopcionDTO> adopcionesCanceladas = new List<SolicitudDeAdopcionDTO>();

            foreach (SolicitudDeAdopcion solicitud in solicitudes)
            {
                // obtengo el usuario asociado al adoptante
                Usuario? usuarioAdoptante = await _repositoryManager.UsuarioRepository.GetByIdAsync(solicitud.Id_Adoptante, Infrastructure.Enums.IncludeTypes.REFERENCE_TABLE_NAME, "Barrio");
                // obtengo el adoptante asociado
                //Adoptante? adoptante = await _repositoryManager.AdoptanteRepository.GetByIdAsync(solicitud.Id_Adoptante);

                if (usuarioAdoptante is null)
                    throw new ArgumentNullException($"El adoptante de la solicitud Nº {solicitud.Id} no existe.");

                // obtengo el animal a mostrar
                Animal? animal = await _repositoryManager.AnimalRepository.GetByIdAsync(solicitud.Id_Animal);

                SolicitudDeAdopcionDTO solicitudDTO = this.MapSolicitudEntityToDTO(solicitud);
                solicitudDTO.Nombre = usuarioAdoptante.NombreUsuario;
                solicitudDTO.Ubicacion = usuarioAdoptante.Barrio.Nombre;
                solicitudDTO.NombreAnimal = animal!.Nombre;
                solicitudDTO.FotoAnimal = animal.Fotografia;

                if (solicitud.FechaFinalizacion is not null)
                    adopcionesExitosas.Add(solicitudDTO);
                else if (solicitud.EstaActivo && !solicitud.Aprobada)
                    pendientesDeAprobacion.Add(solicitudDTO);
                else if (solicitud.EstaActivo && solicitud.Aprobada)
                {
                    // verifico si tiene al menos un turno
                    bool existeAlgunTurno;
                    if (!solicitudDTO.EnEtapaDeSeguimiento)
                    {
                        existeAlgunTurno = await _repositoryManager.TurnoRepository
                        .ExistsAsync(t => t.Id_SolicitudDeAdopcion.Equals(solicitud.Id) && t.EstaActivo);
                    }
                    else
                    {
                        existeAlgunTurno = await _repositoryManager.SeguimientoRepository
                        .ExistsAsync(seg => seg.Id_SolicitudDeAdopcion.Equals(solicitud.Id) && seg.EstaActivo);
                    }
                    solicitudDTO.ExisteAlgunTurno = existeAlgunTurno;
                    adopcionesEnCurso.Add(solicitudDTO);
                }
                else
                {
                    // obtengo la fecha y hora de cancelación de la adopción
                    CancelacionDeAdopcion? adopcionCancelada = await _repositoryManager.CancelacionDeAdopcionRepository.FindByAsync(ca => ca.Id_Solicitud.Equals(solicitud.Id));
                    solicitudDTO.FechaCancelacion = adopcionCancelada!.FechaDeCancelacion.ToString("d");
                    solicitudDTO.HoraCancelacion = adopcionCancelada!.FechaDeCancelacion.ToString("t");
                    adopcionesCanceladas.Add(solicitudDTO);
                }
            }

            return new SolicitudDeAdopcionResponseDTO()
            {
                PendientesDeAprobacion = pendientesDeAprobacion,
                AdopcionesEnCurso = adopcionesEnCurso,
                AdopcionesExitosas = adopcionesExitosas,
                AdopcionesCanceladas = adopcionesCanceladas
            };
        }

        public async Task<SolicitudDeAdopcionResponseVeterinariaDTO> GetSolicitudesVeterinaria(IIdentity? identity)
        {
            try
            {
                // obtengo el id de la veterinaria
                int veterinariaId = await _repositoryManager.UsuarioRepository.GetUserLoggedId(identity);

                // obtengo todos los planes de la veterinaria (para después obtener las solicitudes vinculadas a los seguimientos)
                IEnumerable<PlanDeVacunacion> planesDeVacunacion = await _repositoryManager.PlanDeVacunacionRepository
                    .FindAllByAsync(plan => plan.Id_Veterinaria.Equals(veterinariaId));

                List<SolicitudDeAdopcion> solicitudes = new List<SolicitudDeAdopcion>();

                foreach (PlanDeVacunacion plan in planesDeVacunacion)
                {
                    SolicitudDeAdopcion? solicitud = await _repositoryManager.SolicitudDeAdopcionRepository
                        .GetByIdAsync(plan.Id_SolicitudDeAdopcion, IncludeTypes.REFERENCE_TABLE_NAME, "Animal");

                    if(solicitud is not null)
                        solicitudes.Add(solicitud); // agrego la solicitud vinculada a la veterinaria a la lista
                }

                // instancio las listas para catalogar las solicitudes en actuales o pasadas
                List<SolicitudDeAdopcionDTO> solicitudesActuales = new List<SolicitudDeAdopcionDTO>();
                List<SolicitudDeAdopcionDTO> solicitudesPasadas = new List<SolicitudDeAdopcionDTO>();

                foreach (SolicitudDeAdopcion solicitud in solicitudes)
                {
                    Adoptante? adoptante = await _repositoryManager.AdoptanteRepository
                        .GetByIdAsync(solicitud.Id_Adoptante, IncludeTypes.REFERENCE_TABLE_NAME, "Usuario");

                    Refugio? refugio = await _repositoryManager.RefugioRepository
                        .GetByIdAsync(solicitud.Id_Refugio, IncludeTypes.REFERENCE_TABLE_NAME, "Usuario");

                    if (adoptante is null || refugio is null)
                        throw new ArgumentException("El adoptante o el refugio de la solicitud no existe.");

                    // obtengo los barrios tanto del adoptante como del refugio
                    Barrio? adoptanteBarrio = await _repositoryManager.BarrioRepository.GetByIdAsync(adoptante.Usuario.Id_Barrio);
                    Barrio? refugioBarrio = await _repositoryManager.BarrioRepository.GetByIdAsync(refugio.Usuario.Id_Barrio);

                    SolicitudDeAdopcionDTO solicitudDTO = this.MapSolicitudEntityToDTO(solicitud);
                    string ubicacionRefugio = string.Join(", ", refugio.Usuario.Direccion, refugioBarrio?.Nombre);
                    solicitudDTO.Nombre = string.Concat(adoptante.Usuario.NombreUsuario, "*", refugio.Usuario.NombreUsuario);
                    solicitudDTO.Ubicacion = string.Concat(adoptanteBarrio?.Nombre, "*", ubicacionRefugio);
                    solicitudDTO.NombreAnimal = solicitud.Animal.Nombre;
                    solicitudDTO.FotoAnimal = solicitud.Animal.Fotografia;

                    if(solicitud.EstaActivo)
                        solicitudesActuales.Add(solicitudDTO);
                    else
                        solicitudesPasadas.Add(solicitudDTO);
                }

                return new SolicitudDeAdopcionResponseVeterinariaDTO()
                {
                    SolicitudesActuales = solicitudesActuales,
                    SolicitudesPasadas = solicitudesPasadas
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un problema al obtener las solicitudes vinculadas a la veterinaria. Causa: " + ex.Message);
            }
        }

        private SolicitudDeAdopcionDTO MapSolicitudEntityToDTO(SolicitudDeAdopcion solicitud)
        {
            SolicitudDeAdopcionDTO solicitudDTO = new SolicitudDeAdopcionDTO();
            solicitudDTO.Id = solicitud.Id;
            solicitudDTO.FechaInicio = solicitud.FechaInicio.ToString("d");
            solicitudDTO.HoraInicio = solicitud.FechaInicio.ToString("t");
            solicitudDTO.FechaFinalizacion = solicitud.FechaFinalizacion.HasValue ? solicitud.FechaFinalizacion.Value.ToString("d") : null;
            solicitudDTO.HoraFinalizacion = solicitud.FechaFinalizacion.HasValue ? solicitud.FechaFinalizacion.Value.ToString("t") : null;
            solicitudDTO.Aprobada = solicitud.Aprobada;
            solicitudDTO.EstaActivo = solicitud.EstaActivo;
            solicitudDTO.Id_Adoptante = solicitud.Id_Adoptante;
            solicitudDTO.Id_Animal = solicitud.Id_Animal;
            solicitudDTO.Id_Refugio = solicitud.Id_Refugio;
            solicitudDTO.EnEtapaDeSeguimiento = solicitud.EnEtapaDeSeguimiento;

            return solicitudDTO;
        }

        public async Task AprobarSolicitudDeAdopcion(IIdentity? identity, int solicitudId)
        {
            // verifico si el usuario es válido
            if (identity is null || !identity.IsAuthenticated)
                throw new UnauthorizedAccessException("No tiene los permisos para esta acción.");

            // obtengo el id del usuario que estaba en el token
            ClaimsIdentity? claimsIdentity = identity as ClaimsIdentity;
            int refugioId = Convert.ToInt32(claimsIdentity!.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (!await _repositoryManager.UsuarioRepository.ExistsAsync(u => u.Id.Equals(refugioId)))
                throw new ArgumentException("El refugio no existe.");

            SolicitudDeAdopcion? solicitud = await _repositoryManager.SolicitudDeAdopcionRepository.GetByIdAsync(solicitudId);

            if (solicitud is null)
                throw new ArgumentException("La solicitud a aprobar no existe.");

            solicitud.Aprobada = true;
            await _repositoryManager.SolicitudDeAdopcionRepository.UpdateAsync(solicitud);
        }

        public async Task HabilitarSeguimientoDeVacunaciones(IIdentity? identity, int solicitudId, string nombreVeterinaria)
        {
            try
            {
                // obtengo el id del refugio logueado
                int refugioId = await _repositoryManager.UsuarioRepository.GetUserLoggedId(identity);

                // obtengo la solicitud verificando que corresponde al refugio logueado
                SolicitudDeAdopcion? solicitud = await _repositoryManager.SolicitudDeAdopcionRepository
                    .FindByAsync(s => s.Id.Equals(solicitudId) && s.Id_Refugio.Equals(refugioId));

                if (solicitud is null)
                    throw new ArgumentException("La solicitud indicada es incorrecta o no existe.");

                Veterinaria? veterinaria = await _repositoryManager.VeterinariaRepository
                    .FindByAsync(v => v.Nombre.Equals(nombreVeterinaria));

                if (veterinaria is null)
                    throw new ArgumentException("La veterinaria elegida es incorrecta o no existe.");

                // creo el enlace entre la solicitud y la veterinaria elegida
                await _repositoryManager.PlanDeVacunacionRepository
                    .CreateAsync(new PlanDeVacunacion()
                    {
                        Id_SolicitudDeAdopcion = solicitudId,
                        Id_Veterinaria = veterinaria.Id,
                        EstaActivo = true
                    });

                // actualizo la solicitud para marcarla como "en etapa de seguimiento"
                solicitud.EnEtapaDeSeguimiento = true;
                await _repositoryManager.SolicitudDeAdopcionRepository.UpdateAsync(solicitud);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo habilitar la solicitud para seguimiento. Causa: " + ex.Message);
            }
        }

        public async Task FinalizarProcesoDeAdopcion(IIdentity? identity, int solicitudId)
        {
            try
            {
                // obtengo el id del refugio que va a concluir la adopción
                int refugioId = await _repositoryManager.UsuarioRepository.GetUserLoggedId(identity);

                // obtengo la solicitud asociada al refugio
                SolicitudDeAdopcion? solicitud = await _repositoryManager.SolicitudDeAdopcionRepository
                    .FindByAsync(s => s.Id.Equals(solicitudId) && s.Id_Refugio.Equals(refugioId));

                if (solicitud is null)
                    throw new DirectoryNotFoundException("La solicitud no existe o no está asociada a su refugio.");

                solicitud.FechaFinalizacion = DateTime.Now;
                solicitud.EstaActivo = false;
                await _repositoryManager.SolicitudDeAdopcionRepository.UpdateAsync(solicitud);
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrió un error al finalizar el proceso de adopción. Causa: " + ex.Message);
            }
        }
    }
}
