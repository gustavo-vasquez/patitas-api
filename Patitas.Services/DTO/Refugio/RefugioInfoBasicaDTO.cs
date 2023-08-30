using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Refugio
{
    public class RefugioInfoBasicaDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Barrio { get; set; } = string.Empty;
        public double Puntaje { get; set; }
        public int CantidadDeComentarios { get; set; }
    }
}
