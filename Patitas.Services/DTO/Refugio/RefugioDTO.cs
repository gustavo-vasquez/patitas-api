using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Refugio
{
    public class RefugioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public double Puntaje { get; set; }
        public string? Fotografia { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public string Barrio { get; set; } = string.Empty;
    }
}
