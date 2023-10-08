using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class Refugio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(50)]
        public string RazonSocial { get; set; } = string.Empty;
        public string? Fotografia { get; set; }

        [StringLength(50)]
        public string NombreResponsable { get; set; } = string.Empty;

        [StringLength(50)]
        public string ApellidoResponsable { get; set; } = string.Empty;

        [StringLength(100)]
        public string? SitioWeb { get; set; }

        [StringLength(200)]
        public string? Descripcion { get; set; }

        [StringLength(100)]
        public string DiasDeAtencion { get; set; } = string.Empty;

        [StringLength(2)]
        public string HorarioApertura { get; set; } = string.Empty;

        [StringLength(2)]
        public string HorarioCierre { get; set; } = string.Empty;

        [ForeignKey("Id")]
        public Usuario Usuario { get; set; } = null!;

        // Relaciones 1 a N
        // 1 Refugio <--> N Comentarios
        public ICollection<Comentario> Comentarios { get; } = new List<Comentario>();

        // 1 refugio <--> N animales
        public ICollection<Animal> Animales { get; } = new List<Animal>();

        // 1 refugio <--> N solicitudes
        public ICollection<SolicitudDeAdopcion> SolicitudesDeAdopcion { get; } = new List<SolicitudDeAdopcion>();

        // 1 refugio <--> N turnos
        public ICollection<Turno> Turnos { get; } = new List<Turno>();

        // 1 refugio <--> N formularios pre-adopción
        public ICollection<FormularioPreAdopcion> FormulariosPreAdopcion { get; } = new List<FormularioPreAdopcion>();

        // Relaciones N a N
        public ICollection<Veterinaria> Veterinarias { get; } = new List<Veterinaria>();
    }
}
