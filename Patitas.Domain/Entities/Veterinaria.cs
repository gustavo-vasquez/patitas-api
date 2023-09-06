using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class Veterinaria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(50)]
        public string RazonSocial { get; set; } = string.Empty;
        public string? Fotografia { get; set; }

        [StringLength(200)]
        public string Especialidades { get; set; } = string.Empty;
        public DateTime FechaFundacion { get; set; }

        [StringLength(50)]
        public string? TelefonoAlternativo { get; set; }

        [StringLength(100)]
        public string? SitioWeb { get; set; }

        [StringLength(200)]
        public string? Descripcion { get; set;}

        [StringLength(100)]
        public string DiasDeAtencion { get; set; } = string.Empty;

        [StringLength(2)]
        public string HorarioApertura { get; set; } = string.Empty;

        [StringLength(2)]
        public string HorarioCierre { get; set; } = string.Empty;

        [ForeignKey("Id")]
        public Usuario Usuario { get; set; } = null!;

        // 1 veterinaria <--> N seguimientos de vacunacion
        public ICollection<SeguimientoDeVacunacion> SeguimientosDeVacunacion { get; } = new List<SeguimientoDeVacunacion>();

        // Relaciones N a N
        public ICollection<Refugio> Refugios { get; } = new List<Refugio>();
    }
}
