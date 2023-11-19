using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class Turno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaProgramada { get; set; }
        public bool EstaConfirmado { get; set; }
        public bool Asistio { get; set; }
        public bool EstaActivo { get; set; }
        public bool PorReprogramar { get; set; }

        [StringLength(200)]
        public string MotivoDeReprogramacion { get; set; } = string.Empty;
        public int Id_SolicitudDeAdopcion { get; set; }
        public int Id_Adoptante { get; set; }
        public int Id_Refugio { get; set; }
        
        [StringLength(200)]
        public string InformeDeVisita { get; set; } = string.Empty;

        // 1 a N
        // 1 solicitud <--> N turnos
        [ForeignKey(nameof(Id_SolicitudDeAdopcion))]
        public SolicitudDeAdopcion SolicitudDeAdopcion { get; set; } = null!;

        // 1 adoptante <--> N turnos
        [ForeignKey(nameof(Id_Adoptante))]
        public Adoptante Adoptante { get; set; } = null!;

        // 1 refugio <--> N turnos
        [ForeignKey(nameof(Id_Refugio))]
        public Refugio Refugio { get; set; } = null!;
    }
}
