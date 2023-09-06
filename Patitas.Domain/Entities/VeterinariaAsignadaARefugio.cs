using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    [PrimaryKey(nameof(Id_Veterinaria), nameof(Id_Refugio))] // Indico PK compuesta
    public class VeterinariaAsignadaARefugio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Veterinaria { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Refugio { get; set; }
        public DateTime FechaDeAsignacion { get; set; }
    }
}
