using Patitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO
{
    public class AdopterProfileInfoDTO
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? FotoDePerfil { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public long? DNI { get; set; }
    }
}
