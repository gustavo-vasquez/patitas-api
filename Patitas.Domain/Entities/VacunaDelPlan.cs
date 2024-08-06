using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Domain.Entities
{
    public class VacunaDelPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Id_PlanDeVacunacion { get; set; }
        public int Id_Vacuna { get; set; }
        public byte NroDosis { get; set; }
        public DateTime? FechaDeAplicacion { get; set; }

        // 1 a N: 1 plan de vacunación <--> N vacuna del plan
        [ForeignKey(nameof(Id_PlanDeVacunacion))]
        public PlanDeVacunacion PlanDeVacunacion { get; set; } = null!;

        // 1 a N: 1 vacuna <--> N vacuna del plan
        [ForeignKey(nameof(Id_Vacuna))]
        public Vacuna Vacuna { get; set; } = null!;
    }
}
