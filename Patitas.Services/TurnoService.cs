using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Services.Contracts;
using Patitas.Services.DTO.Turno;
using Patitas.Services.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    internal sealed class TurnoService : ITurnoService
    {
        private readonly IRepositoryManager _repositoryManager;

        public TurnoService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<TurnoResponseDTO> GetTurnos(IIdentity? identity, RolTypes rol)
        {
            int adoptanteId = await _repositoryManager.UsuarioRepository.GetUserLoggedId(identity);

            IEnumerable<Turno> turnos = await _repositoryManager.TurnoRepository.FindAllByAsync(t => t.Id_Adoptante.Equals(adoptanteId));
            List<TurnoTarjetaDTO> turnosActivos = new List<TurnoTarjetaDTO>();
            List<TurnoTarjetaDTO> turnosPasados = new List<TurnoTarjetaDTO>();
            List<FiltroRefugiosDTO> filtroRefugios = new List<FiltroRefugiosDTO>();

            foreach (Turno turno in turnos)
            {
                Refugio? refugio = await _repositoryManager.RefugioRepository.GetByIdAsync(turno.Id_Refugio);

                if (refugio is null)
                    throw new ArgumentException("El refugio asociado al turno no existe.");

                if (!filtroRefugios.Any(f => f.Id.Equals(refugio.Id) && f.Nombre.Equals(refugio.Nombre)))
                    filtroRefugios.Add(new FiltroRefugiosDTO { Id = refugio.Id, Nombre = refugio.Nombre });

                TurnoTarjetaDTO turnoDTO = this.MapTurnoEntityToDTO(turno, refugio.Nombre);

                if (turno.EstaActivo && turno.FechaProgramada > DateTime.Now)
                    turnosActivos.Add(turnoDTO);
                else
                    turnosPasados.Add(turnoDTO);
            }

            return new TurnoResponseDTO
            {
                TurnosActivos = turnosActivos,
                TurnosPasados = turnosPasados
            };
        }

        public async Task<TurnoResponseDTO> GetTurnosRefugio(IIdentity? identity)
        {
            int refugioId = await _repositoryManager.UsuarioRepository.GetUserLoggedId(identity);

            IEnumerable<Turno> turnos = await _repositoryManager.TurnoRepository.FindAllByAsync(t => t.Id_Refugio.Equals(refugioId));
            List<TurnoTarjetaDTO> turnosActivos = new List<TurnoTarjetaDTO>();
            List<TurnoTarjetaDTO> turnosPasados = new List<TurnoTarjetaDTO>();

            foreach (Turno turno in turnos)
            {
                Usuario? usuarioAdoptante = await _repositoryManager.UsuarioRepository.GetByIdAsync(turno.Id_Adoptante);

                if (usuarioAdoptante is null)
                    throw new ArgumentException("El adoptante asociado al turno no existe.");

                TurnoTarjetaDTO turnoDTO = this.MapTurnoEntityToDTO(turno, usuarioAdoptante.NombreUsuario);

                if (turno.EstaActivo && turno.FechaProgramada > DateTime.Now)
                    turnosActivos.Add(turnoDTO);
                else
                    turnosPasados.Add(turnoDTO);
            }

            return new TurnoResponseDTO
            {
                TurnosActivos = turnosActivos,
                TurnosPasados = turnosPasados
            };
        }

        private TurnoTarjetaDTO MapTurnoEntityToDTO(Turno turno, string nombre)
        {
            TurnoTarjetaDTO turnoDTO = new TurnoTarjetaDTO();
            turnoDTO.Id = turno.Id;
            turnoDTO.FechaProgramada = turno.FechaProgramada.ToString("d");
            turnoDTO.HoraProgramada = turno.FechaProgramada.ToString("t");
            turnoDTO.EstaConfirmado = turno.EstaConfirmado;
            turnoDTO.Asistio = turno.Asistio;
            turnoDTO.EstaVencido = DateTime.Now > turno.FechaProgramada;
            turnoDTO.PorReprogramar = turno.PorReprogramar;
            turnoDTO.EstaActivo = turno.EstaActivo;
            turnoDTO.Nombre = nombre;

            return turnoDTO;
        }
    }
}
