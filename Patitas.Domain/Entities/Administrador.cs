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

        // N a N
        // N Administradores <--(ModeracionDePublicacion)--> N Publicaciones
        public ICollection<Publicacion> Publicaciones { get; } = new List<Publicacion>();
    }
}
