using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Refugio
{
    public class ComentarioDelRefugioDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public bool EstaActivo { get; set; }
        public DateTime? FechaEdicion { get; set; }
        public bool PendienteDeAprobacion { get; set; }
        public int? AprobadoPor_IdAdministrador { get; set; } // Nullable porque la aprobación es post-creación del comentario
        public byte Nro_Estrellas { get; set; }
        public int Id_Refugio { get; set; }
        public int Id_Adoptante { get; set; }
    }
}
