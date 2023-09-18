using Microsoft.EntityFrameworkCore;

namespace Patitas.Domain.Entities
{
    [PrimaryKey(nameof(Id_Animal), nameof(Id_Vacuna))]
    public class AnimalVacuna
    {
        public int Id_Animal { get; set; }
        public int Id_Vacuna { get; set; }
        public int NroDosisAplicada { get; set; }
        public DateTime FechaDeAplicacion { get; set; }
        public bool FueParteDeAdopcion { get; set; }
    }
}
