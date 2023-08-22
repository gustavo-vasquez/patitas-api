using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    [PrimaryKey(nameof(Id_Publicacion), nameof(Id_Administrador))] // clave compuesta
    public class ModeracionDePublicacion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Publicacion { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_Administrador { get; set; }

        [StringLength(200)]
        public string Motivo { get; set; } = string.Empty;
        public bool FueEditado { get; set; }
        public bool FueEliminado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
