using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class SolicitudDeAdopcion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public bool Aprobada { get; set; }
        public bool EstaActivo { get; set; }
        public int Id_Adoptante { get; set; }
        public int Id_Animal { get; set; }
        public int Id_Refugio { get; set; }
        public bool EnEtapaDeSeguimiento { get; set; }

        // 1 a N
        // 1 adoptante <--> N solicitudes
        [ForeignKey(nameof(Id_Adoptante))]
        public Adoptante Adoptante { get; set; } = null!;

        // 1 animal <--> N solicitudes
        [ForeignKey(nameof(Id_Animal))]
        public Animal Animal { get; set; } = null!;

        // 1 refugio <--> N solicitudes
        [ForeignKey(nameof(Id_Refugio))]
        public Refugio Refugio { get; set; } = null!;

        // 1 solicitud <--> N turnos
        public ICollection<Turno> Turnos { get; } = new List<Turno>();

        // 1 solicitud <--> N seguimientos de vacunacion
        public ICollection<SeguimientoDeVacunacion> SeguimientosDeVacunacion { get; } = new List<SeguimientoDeVacunacion>();

        // 1 solicitud <--> N cancelacion de adopcion
        public ICollection<CancelacionDeAdopcion> CancelacionesDeAdopcion { get; } = new List<CancelacionDeAdopcion>();

        // 1 a 1
        // 1 solicitud de adopcion <--> 1 plan de vacunacion
        public PlanDeVacunacion PlanDeVacunacion { get; set; } = null!;

        // 1 solicitud de adopción <--> 1 formulario de pre-adopción
        public FormularioPreAdopcion FormularioPreAdopcion { get; set; } = null!;
    }
}
