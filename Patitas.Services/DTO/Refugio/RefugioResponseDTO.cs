using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Refugio
{
    public class RefugioResponseDTO
    {
        public RefugioInfoBasicaDTO InfoBasica { get; set; } = null!;
        public IEnumerable<AnimalDelRefugioDTO> Animales { get; set; } = null!;
        public IEnumerable<ComentarioDelRefugioDTO> Comentarios { get; set; } = null!;
        public IEnumerable<VeterinariaAsociadaDTO> VeterinariasAsociadas { get; set; } = null!;
        public RefugioInfoCompletaDTO InfoCompleta { get; set; } = null!;
        public bool PuedeComentar { get; set; }
        public bool SesionExpirada { get; set; }
    }
}
