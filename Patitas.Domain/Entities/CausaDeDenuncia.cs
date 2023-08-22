using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class CausaDeDenuncia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; } = string.Empty;
        
        // 1 a N
        // 1 Causa de denuncia <--> N Denuncias
        public ICollection<Denuncia> Denuncias { get; } = new List<Denuncia>();
    }
}
