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

                FormularioPreAdopcion nuevoFormulario = new FormularioPreAdopcion
                {
                    Id_Adoptante = adoptanteId,
                    Id_SolicitudDeAdopcion = nuevaSolicitud.Id,
                    Motivo = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.Motivo,
                    TuvoMascota = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TuvoMascota ?? false,
                    TieneMascotas = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TieneMascotas ?? false,
                    DescripcionMascotas = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.DescripcionMascotas,
                    ViveSolo = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.ViveSolo ?? false,
                    TieneVeterinariaCerca = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TieneVeterinariaCerca ?? false,
                    ViveEnCasa = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.ViveEnCasa ?? false,
                    ViveEnDepartamento = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.ViveEnDepartamento ?? false,
                    CantidadDeAmbientes = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.CantidadDeAmbientes ?? 0,
                    TienePatio = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TienePatio ?? false,
                    TieneBalcon = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TieneBalcon ?? false,
                    TieneRedEnVentanas = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TieneRedEnVentanas ?? false,
                    ConoceLeyDeMaltratoAnimal = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.ConoceLeyDeMaltratoAnimal ?? false,
                    FrecuenciaAnimalSolo = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.FrecuenciaAnimalSolo!,
                    TieneConocidosEnCasoDeEmergencia = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TieneConocidosEnCasoDeEmergencia ?? false,
                    TieneSalarioAcordeAGastos = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TieneSalarioAcordeAGastos ?? false,
                    TieneConocidosQueLoAconsejen = solicitudDeAdopcionRequestDTO.FormularioPreAdopcionDTO.TieneConocidosQueLoAconsejen ?? false
                };

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
