using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class Adoptante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Nombre { get; set; }

        [StringLength(50)]
        public string? Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public long? DNI { get; set; }

        [ForeignKey("Id")]
        public Usuario Usuario { get; set; } = null!;
        public FormularioPreAdopcion? FormularioPreAdopcion { get; set; }

        // Relaciones 1 a N
        // 1 Adoptante <--> N Comentarios
        public ICollection<Comentario> Comentarios { get; } = new List<Comentario>();

        // 1 adoptante <--> N solicitudes
        public ICollection<SolicitudDeAdopcion> SolicitudesDeAdopcion { get; } = new List<SolicitudDeAdopcion>();

        // 1 adoptante <--> N turnos
        public ICollection<Turno> Turnos { get; } = new List<Turno>();

        // N a N
        // N adoptantes <--(AdoptanteCancelaAdopcion)--> N solicitudes
        //public ICollection<SolicitudDeAdopcion> SolicitudesDeAdopcionCanceladas { get; } = new List<SolicitudDeAdopcion>();
    }
}
