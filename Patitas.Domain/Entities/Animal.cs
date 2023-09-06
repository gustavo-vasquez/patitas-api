using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        public int Nacimiento { get; set; }
        public char Genero { get; set; }
        public string Fotografia { get; set; } = string.Empty;

        [StringLength(200)]
        public string SituacionPrevia { get; set; } = string.Empty;
        public int Peso { get; set; }
        public decimal Altura { get; set; }
        public bool Esterilizado { get; set; }
        public bool Desparasitado { get; set; }
        public DateTime FechaIngreso { get; set; }

        [StringLength(200)]
        public string? DescripcionAdicional { get; set; }
        public bool EstaAdoptado { get; set; }
        public DateTime? FechaAdopcion { get; set; }
        public int Id_Raza { get; set; }
        public int Id_Refugio { get; set; }

        [ForeignKey(nameof(Id_Raza))]
        public Raza Raza { get; set; } = null!;

        [ForeignKey(nameof(Id_Refugio))]
        public Refugio Refugio { get; set; } = null!;

        // 1 a N
        // 1 animal <--> N solicitudes
        public ICollection<SolicitudDeAdopcion> SolicitudesDeAdopcion { get; } = new List<SolicitudDeAdopcion>();

        // N a N
        // N animales <--(AnimalVacuna)--> N vacunas
        public ICollection<Vacuna> Vacunas { get; } = new List<Vacuna>();
    }
}
