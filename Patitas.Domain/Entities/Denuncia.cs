using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patitas.Domain.Entities
{
    public class Denuncia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        [StringLength(200)]
        public string? DescripcionAdicional { get; set; }
        public int Id_CausaDeDenuncia { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Publicacion { get; set; }

        // 1 a N
        // 1 Causa de denuncia <--> N Denuncias
        [ForeignKey(nameof(Id_CausaDeDenuncia))]
        public CausaDeDenuncia CausaDeDenuncia { get; set; } = null!;

        // 1 Usuario <--> N Denuncias
        [ForeignKey(nameof(Id_Usuario))]
        public Usuario Usuario { get; set; } = null!;

        // 1 Publicacion <--> N Denuncias
        [ForeignKey(nameof(Id_Publicacion))]
        public Publicacion Publicacion { get; set; } = null!;
    }
}
