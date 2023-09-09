using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Password { get; set; } = string.Empty;

        public string? FotoDePerfil { get; set; }

        [StringLength(50)]
        public string? Telefono { get; set; }

        [StringLength(50)]
        public string? Direccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EstaActivo { get; set; }
        public int Id_Barrio { get; set; }
        public int Id_Rol { get; set; }

        // 1 a N
        // 1 barrio <--> N usuarios
        [ForeignKey("Id_Barrio")]
        public Barrio Barrio { get; set; } = null!;
        
        // 1 rol <--> N usuarios
        [ForeignKey("Id_Rol")]
        public Rol RolUsuario { get; set; } = null!;

        // 1 usuario <--> N denuncias
        public ICollection<Denuncia> Denuncias { get; } = new List<Denuncia>();

        // 1 usuario <--> N cancelacion de adopcion
        public ICollection<CancelacionDeAdopcion> CancelacionesDeAdopcion { get; } = new List<CancelacionDeAdopcion>();

        // 1 a 1
        public Adoptante? Adoptante { get; set; }
        public Administrador? Administrador { get; set; }
        public Refugio? Refugio { get; set; }
        public Veterinaria? Veterinaria { get; set; }
    }
}
