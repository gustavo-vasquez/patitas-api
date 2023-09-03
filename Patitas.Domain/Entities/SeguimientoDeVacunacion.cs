using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class SeguimientoDeVacunacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime FechaDeAsignacion { get; set; }
        public bool PorReprogramar { get; set; }
        public bool EstaAplicada { get; set; }
        public byte NroDosis { get; set; }

        [StringLength(50)]
        public string? NroLote { get; set; }
        public int Id_SolicitudDeAdopcion { get; set; }
        public int Id_Vacuna { get; set; }
        public int Id_Veterinaria { get; set; }

        [ForeignKey(nameof(Id_SolicitudDeAdopcion))]
        public SolicitudDeAdopcion SolicitudDeAdopcion { get; set; } = null!;

        [ForeignKey(nameof(Id_Vacuna))]
        public Vacuna Vacuna { get; set; } = null!;

        [ForeignKey(nameof(Id_Veterinaria))]
        public Veterinaria Veterinaria { get; set; } = null!;
    }
}
