using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class Raza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        public int Id_Especie { get; set; }

        [ForeignKey(nameof(Id_Especie))]
        public Especie Especie { get; set; } = null!;

        public ICollection<Animal> Animales { get; } = new List<Animal>();
    }
}
