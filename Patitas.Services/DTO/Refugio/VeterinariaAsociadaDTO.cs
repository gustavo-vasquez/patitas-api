using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Refugio
{
    public class VeterinariaAsociadaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Barrio { get; set; } = string.Empty;
        public string? Fotografia { get; set; }
        public string Especialidades { get; set; } = string.Empty;
        public DateTime FechaFundacion { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public string? TelefonoAlternativo { get; set; }
        public string Email { get; set;} = string.Empty;
        public string? SitioWeb { get; set; }
        public string? Descripcion { get; set; }
        public string DiasDeAtencion { get; set; } = string.Empty;
        public string HorarioApertura { get; set; } = string.Empty;
        public string HorarioCierre { get; set; } = string.Empty;
    }
}
