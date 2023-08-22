using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class Publicacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Contenido { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEdicion { get; set; }
        public bool EditadoPorAdministrador { get; set; }
        public bool EstaActivo { get; set; }
        public int Id_Tema { get; set; }
        public int Id_Usuario { get; set; }
        public int? RespondeA_IdPublicacion { get; set; } // si "responde a" es null. Es el post de apertura

        // 1 a N
        // 1 tema <--> N publicaciones
        [ForeignKey(nameof(Id_Tema))]
        public Tema Tema { get; set; } = null!;

        // 1 usuario <--> N publicaciones
        [ForeignKey(nameof(Id_Usuario))]
        public Usuario Usuario { get; set; } = null!;

        // 1 publicacion <--> N denuncias
        public ICollection<Denuncia> Denuncias { get; } = new List<Denuncia>();

        // 1 a 1
        // 1 publicacion <--> N publicaciones (como respuestas)

        [ForeignKey(nameof(RespondeA_IdPublicacion))]
        public Publicacion? Respuesta { get; set; } = null!;
        public ICollection<Publicacion> Respuestas { get; } = new List<Publicacion>();

        // N a N
        // N Publicaciones <--(ModeracionDePublicacion)--> N Administradores
        public ICollection<Administrador> Administradores { get; } = new List<Administrador>();
    }
}
