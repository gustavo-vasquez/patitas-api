using Patitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Adoptante
{
    public class AdoptantePerfilCompletoDTO
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? FotoDePerfil { get; set; }
        public string? Telefono { get; set; }
        public string NombreBarrio { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public string FechaCreacion { get; set; } = string.Empty;
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? FechaNacimiento { get; set; }
        public long? DNI { get; set; }
        public int CantidadAdopcionesExitosas { get; set; }
        public int CantidadAdopcionesFalladas { get; set; }
    }
}
