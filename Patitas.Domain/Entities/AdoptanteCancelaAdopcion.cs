using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    [PrimaryKey(nameof(Id_Adoptante), nameof(Id_SolicitudAdopcion))]
    public class AdoptanteCancelaAdopcion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Adoptante { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_SolicitudAdopcion { get; set; }

        [StringLength(200)]
        public string Motivo { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }
}
