using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Refugio
{
    public class SolicitudDetalleResponseDTO
    {
        public int NroSolicitud { get; set; }
        public string FechaInicioSolicitud { get; set; } = string.Empty;
        public string HoraInicioSolicitud { get; set; } = string.Empty;
        public string? FechaFinSolicitud { get; set; }
        public string? HoraFinSolicitud { get; set; }
        public bool PendienteDeAprobacion { get; set; }
        public bool AdopcionEnCurso { get; set; }
        public bool AdopcionExitosa { get; set; }
        public bool AdopcionCancelada { get; set; }
        public bool Aprobada { get; set; }
        public bool EstaActivo { get; set; }
        public int Id_Adoptante { get; set; }
        public int Id_Animal { get; set; }
        public int Id_Refugio { get; set; }
        public bool EnEtapaDeSeguimiento { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string EmailUsuario { get; set; } = string.Empty;
        public string FechaRegistroAdoptante { get; set; } = string.Empty;
        public string HoraRegistroAdoptante { get; set; } = string.Empty;
        public string? TxtNombre { get; set; }
        public string? TxtApellido { get; set; }
        public string TxtBarrio { get; set; } = string.Empty;
        public string? TxtDireccion { get; set; }
        public string? TxtFechaNacimiento { get; set; }
        public long? TxtDocumento { get; set; }
        public string? TxtTelefono { get; set; }
        public int AdopcionesExitosas { get; set; }
        public int AdopcionesInterrumpidas { get; set; }
        public string ImgAnimal { get; set; } = string.Empty;
        public string NombreAnimal { get; set; } = string.Empty;
        public string RazaAnimal { get; set; } = string.Empty;
        public string GeneroAnimal { get; set; } = string.Empty;
        public string LnkVerFichaCompleta { get; set; }
        public bool SnVerFichaCompleta { get; set; }
        public string LnkTurnos { get; set; }
        public bool TieneTurnoActivo { get; set; }
        public bool SnTurnos { get; set; }
        public string LnkSeguimiento { get; set; }
        public bool SnSeguimiento { get; set; }
        public bool SnPlanVacunacion { get; set; }
        public string TxtMotivo { get; set; } = string.Empty;
        public bool SnTuvoMascota { get; set; }
        public bool SnTieneMascotas { get; set; }
        public bool SnViveSolo { get; set; }
        public bool SnTieneVeterinariaCerca { get; set; }
        public bool SnViveEnCasa { get; set; }
        public bool SnViveEnDepartamento { get; set; }
        public int CantidadAmbientes { get; set; }
        public bool SnTienePatio { get; set; }
        public bool SnTieneBalcon { get; set; }
        public bool SnTieneRedEnVentanas { get; set; }
        public bool SnConoceLeyMaltratoAnimal { get; set; }
        public string FrecuenciaAnimalSolo { get; set; } = string.Empty;
        public bool SnTieneConocidosEnCasoDeEmergencia { get; set; }
        public bool SnTieneSalarioAcordeAGastos { get; set; }
        public bool SnTieneConocidosQueLoAconsejen { get; set; }
    }
}
