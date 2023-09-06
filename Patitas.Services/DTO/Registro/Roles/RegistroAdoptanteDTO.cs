using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patitas.Services.DTO.Registro;

namespace Patitas.Services.DTO.Registro.Roles
{
    public class RegistroAdoptanteDTO : RegistroRequestDTO
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }
        protected override bool EstaActivo { get; set; } = true;
    }
}
