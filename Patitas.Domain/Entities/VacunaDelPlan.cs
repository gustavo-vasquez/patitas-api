using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Domain.Entities
{
    [PrimaryKey(nameof(Id_PlanDeVacunacion), nameof(Id_Vacuna))]
    public class VacunaDelPlan
    {
        public int Id_PlanDeVacunacion { get; set; }
        public int Id_Vacuna { get; set; }
        public int NroDosis { get; set; }
        public DateTime FechaDeAplicacion { get; set; }
    }
}
