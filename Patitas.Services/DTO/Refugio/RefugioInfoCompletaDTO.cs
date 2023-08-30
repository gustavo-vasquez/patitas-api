using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Refugio
{
    public class RefugioInfoCompletaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string NombreResponsable { get; set; } = string.Empty;
        public string ApellidoResponsable { get; set; } = string.Empty;
        public string? SitioWeb { get; set; }
        public string HorarioApertura { get; set; } = string.Empty;
        public string HorarioCierre { get; set; } = string.Empty;
    }
}
