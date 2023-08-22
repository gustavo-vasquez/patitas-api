using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class Administrador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public bool EsFundador { get; set; }

        [ForeignKey("Id")]
        public Usuario Usuario { get; set; } = null!;

        // Relaciones 1 a N
        // Las colecciones sólo tienen getter y se inicializan
        // 1 Administrador <--> N Comentarios (relación opcional)
        public ICollection<Comentario> Comentarios { get; } = new List<Comentario>();

        // N a N
        // N Administradores <--(ModeracionDePublicacion)--> N Publicaciones
        public ICollection<Publicacion> Publicaciones { get; } = new List<Publicacion>();
    }
}
