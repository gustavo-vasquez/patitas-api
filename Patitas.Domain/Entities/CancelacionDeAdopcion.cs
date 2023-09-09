using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Domain.Entities
{
    public class CancelacionDeAdopcion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200)]
        public string Motivo { get; set; } = string.Empty;
        public DateTime FechaDeCancelacion { get; set; }
        public int Id_Solicitud { get; set; }
        public int Id_Usuario { get; set; }

        // 1 a N
        // 1 solicitud <--> N cancelacion de adopcion
        [ForeignKey(nameof(Id_Solicitud))]
        public SolicitudDeAdopcion SolicitudDeAdopcion { get; set; } = null!;

        // 1 usuario <--> N cancelacion de adopcion
        [ForeignKey(nameof(Id_Usuario))]
        public Usuario Usuario { get; set; } = null!;
    }
}
