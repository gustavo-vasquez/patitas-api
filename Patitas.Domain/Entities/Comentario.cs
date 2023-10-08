using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class Comentario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200)]
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime? FechaEdicion { get; set; }
        public byte Nro_Estrellas { get; set; }
        public int Id_Refugio { get; set; }
        public int Id_Adoptante { get; set; }

        // Relaciones 1 a N

        [ForeignKey(nameof(Nro_Estrellas))]
        public DetalleEstrella DetalleEstrella { get; set; } = null!;

        [ForeignKey(nameof(Id_Refugio))]
        public Refugio Refugio { get; set; } = null!;

        [ForeignKey(nameof(Id_Adoptante))]
        public Adoptante Adoptante { get; set; } = null!;
    }
}
