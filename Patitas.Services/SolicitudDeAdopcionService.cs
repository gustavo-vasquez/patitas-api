using Microsoft.AspNetCore.Http;
using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts.Manager;
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
            int adoptanteId = Convert.ToInt32(claimsIdentity!.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            if (!await _repositoryManager.UsuarioRepository.ExistsAsync(u => u.Id.Equals(adoptanteId)))
                throw new ArgumentException("El adoptante no existe.");

            // obtengo todas las solicitudes de adopción del adoptante
            IEnumerable<SolicitudDeAdopcion> solicitudes = await _repositoryManager.SolicitudDeAdopcionRepository.FindAllByAsync(s => s.Id_Adoptante.Equals(adoptanteId));

            // inicializo las listas de los tipos de solicitudes que voy a mostrar en el panel "mis solicitudes"
            List<SolicitudDeAdopcionDTO> pendientesDeAprobacion = new List<SolicitudDeAdopcionDTO>();
            List<SolicitudDeAdopcionDTO> adopcionesEnCurso = new List<SolicitudDeAdopcionDTO>();
            List<SolicitudDeAdopcionDTO> adopcionesExitosas = new List<SolicitudDeAdopcionDTO>();
            List<SolicitudDeAdopcionDTO> adopcionesCanceladas = new List<SolicitudDeAdopcionDTO>();

            foreach (SolicitudDeAdopcion solicitud in solicitudes)
            {
                // obtengo el usuario asociado al refugio
                Usuario? usuarioRefugio = await _repositoryManager.UsuarioRepository.GetByIdAsync(solicitud.Id_Refugio);
                // obtengo el refugio asociado
                Refugio? refugio = await _repositoryManager.RefugioRepository.GetByIdAsync(solicitud.Id_Refugio);
                
                if (usuarioRefugio is null || refugio is null)
                    throw new ArgumentNullException($"El refugio de la solicitud Nº {solicitud.Id} no existe.");

                Barrio? barrio = await _repositoryManager.BarrioRepository.GetByIdAsync(usuarioRefugio.Id_Barrio);
                Animal? animal = await _repositoryManager.AnimalRepository.GetByIdAsync(solicitud.Id_Animal);

                if (solicitud.EstaActivo && !solicitud.Aprobada)
                {
                    var solicitudDTO = this.MapSolicitudEntityToDTO(solicitud, usuarioRefugio, refugio.Nombre, barrio!.Nombre, animal!.Nombre);
                    pendientesDeAprobacion.Add(solicitudDTO);
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

        private SolicitudDeAdopcionDTO MapSolicitudEntityToDTO(
            SolicitudDeAdopcion solicitud,
            Usuario usuarioRefugio,
            string nombreRefugio,
            string nombreBarrio,
            string nombreAnimal)
        {
            SolicitudDeAdopcionDTO solicitudDTO = new SolicitudDeAdopcionDTO();
            solicitudDTO.Id = solicitud.Id;
            solicitudDTO.FechaInicio = solicitud.FechaInicio;
            solicitudDTO.FechaFinalizacion = solicitud.FechaFinalizacion;
            solicitudDTO.Aprobada = solicitud.Aprobada;
            solicitudDTO.EstaActivo = solicitud.EstaActivo;
            solicitudDTO.Id_Adoptante = solicitud.Id_Adoptante;
            solicitudDTO.Id_Animal = solicitud.Id_Animal;
            solicitudDTO.Id_Refugio = solicitud.Id_Refugio;
            solicitudDTO.Nombre = nombreRefugio;
            solicitudDTO.Ubicacion = string.Join(", ", usuarioRefugio.Direccion, nombreBarrio);
            solicitudDTO.NombreAnimal = nombreAnimal;

            return solicitudDTO;
        }
    }
}
