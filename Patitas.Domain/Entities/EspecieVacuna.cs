using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    [PrimaryKey(nameof(Id_Especie), nameof(Id_Vacuna))]
    public class EspecieVacuna
    {
        public int Id_Especie { get; set; }
        public int Id_Vacuna { get; set; }
    }
}
