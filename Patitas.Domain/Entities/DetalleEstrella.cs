using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class DetalleEstrella
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public byte NroEstrella { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; } = string.Empty;

        // Relaciones 1 a N
        public ICollection<Comentario> Comentarios { get; } = new List<Comentario>();
    }
}
