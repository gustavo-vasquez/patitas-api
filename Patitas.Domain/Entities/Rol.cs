using System.ComponentModel.DataAnnotations;

namespace Patitas.Domain.Entities
{
    public class Rol
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        public ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
    }
}
