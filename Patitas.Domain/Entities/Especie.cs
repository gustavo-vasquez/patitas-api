using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class Especie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Raza> Razas { get; set; } = new List<Raza>();

        // N a N
        // N especies <--(EspecieVacuna)--> N vacunas
        public ICollection<Vacuna> Vacunas { get; set; } = new List<Vacuna>();
    }
}
