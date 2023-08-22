using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    [PrimaryKey(nameof(Id_Solicitud), nameof(Id_Vacuna))]
    public class SeguimientoDeVacunacion
    {
        public int Id_Solicitud { get; set; }
        public int Id_Vacuna { get; set; }
        public DateTime FechaDeAsignacion { get; set; }
        public bool PorReprogramar { get; set; }
        public bool EstaAplicada { get; set; }
        public byte NroDosis { get; set; }

        [StringLength(50)]
        public string NroLote { get; set; } = string.Empty;
        public int Id_Veterinaria { get; set; }

        [ForeignKey(nameof(Id_Veterinaria))]
        public Veterinaria Veterinaria { get; set; } = null!;
    }
}
