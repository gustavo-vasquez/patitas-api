using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Adoptante
{
    public class ComentarioCreateDTO
    {
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Contenido { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1, byte.MaxValue, ErrorMessage = "El número de estrellas no es válido.")]
        public byte NroEstrellas { get; set; }
        public int Id_Refugio { get; set; }
    }
}
