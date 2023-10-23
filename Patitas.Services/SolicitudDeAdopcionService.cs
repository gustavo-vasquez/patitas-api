using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Services.Contracts;
using Patitas.Services.DTO.SolicitudDeAdopcion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    }
}
