using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Domain.Entities
{
    public class PlanDeVacunacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Id_SolicitudDeAdopcion { get; set; }
        public int Id_Veterinaria { get; set; }
        public bool EstaActivo { get; set; }
        public bool Completado { get; set; }
        public DateTime? FechaCompletado { get; set; }

        // 1 solicitud de adopcion <--> 1 plan de vacunacion
        [ForeignKey(nameof(Id_SolicitudDeAdopcion))]
        public SolicitudDeAdopcion SolicitudDeAdopcion { get; set; } = null!;

        // 1 veterinaria <--> 1 plan de vacunacion
        [ForeignKey(nameof(Id_Veterinaria))]
        public Veterinaria Veterinaria { get; set; } = null!;

        // 1 a N: 1 plan de vacunación <--> N vacuna del plan
        public ICollection<VacunaDelPlan> VacunasDelPlan { get; } = new List<VacunaDelPlan>();
    }
}
