using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Refugio
{
    public class RefugioPerfilCompletoDTO
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? FotoDePerfil { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public string NombreBarrio { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string FechaCreacion { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string? FotoDelRefugio { get; set; }
        public string NombreResponsable { get; set; } = string.Empty;
        public string ApellidoResponsable { get; set; } = string.Empty;
        public string? SitioWeb { get; set; }
        public string? Descripcion { get; set; }
        public string DiasDeAtencion { get; set;} = string.Empty;
        public string HorarioApertura { get; set;} = string.Empty;
        public string HorarioCierre { get; set; } = string.Empty;
    }
}
