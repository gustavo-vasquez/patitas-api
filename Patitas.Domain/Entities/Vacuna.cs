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
        public string EdadIndicada { get; set; } = string.Empty;

        // 1 vacuna <--> N seguimientos de vacunacion
        public ICollection<SeguimientoDeVacunacion> SeguimientosDeVacunacion { get; } = new List<SeguimientoDeVacunacion>();

        // N a N
        // N animales <--(AnimalVacuna)--> N vacunas
        public ICollection<Animal> Animales { get; } = new List<Animal>();

        // N especies <--(EspecieVacuna)--> N vacunas
        public ICollection<Especie> Especies { get; } = new List<Especie>();

        // N vacunas <--(VacunaDelPlan)--> N planes de vacunación
        public ICollection<PlanDeVacunacion> PlanesDeVacunacion { get; } = new List<PlanDeVacunacion>();
    }
}
