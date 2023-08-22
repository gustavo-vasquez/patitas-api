using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class Vacuna
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        public int CantidadDeDosis { get; set; }

        [StringLength(50)]
        public string EdadAproximada { get; set; } = string.Empty;
        //public bool RequiereDosisDeRefuerzo { get; set; }

        // N a N
        // N animales <--(AnimalVacuna)--> N vacunas
        public ICollection<Animal> Animales { get; } = new List<Animal>();

        // N solicitudes <--(SeguimientoDeVacunacion)--> N vacunas
        public ICollection<SolicitudDeAdopcion> SolicitudesDeAdopcion { get; } = new List<SolicitudDeAdopcion>();

        // N especies <--(EspecieVacuna)--> N vacunas
        public ICollection<Especie> Especies { get; } = new List<Especie>();
    }
}
