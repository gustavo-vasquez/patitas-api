using Patitas.Services.DTO.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.SolicitudDeAdopcion
{
    public class FormularioPreAdopcionDTO
    {
        public int Id { get; set; }
        public int Id_Adoptante { get; set; }
        public int Id_SolicitudDeAdopcion { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        [MaxLength(200, ErrorMessage = ValidationMessages.FIELD_MAX_LENGTH_200)]
        public string Motivo { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public string? TuvoMascota { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public string? TieneMascotas { get; set; }

        [MaxLength(200, ErrorMessage = ValidationMessages.FIELD_MAX_LENGTH_200)]
        public string? DescripcionMascotas { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public string? ViveSolo { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public string? TieneVeterinariaCerca { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public string? ViveEnCasa { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        [RegularExpression($"^[2-4]*$", ErrorMessage = ValidationMessages.NUMBER_NOT_VALID)]
        public byte? CantidadDeAmbientes { get; set; }

        public string[] HogarTiene { get; set; } = new string[2];

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public string? ConoceLeyDeMaltratoAnimal { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        [MaxLength(50, ErrorMessage = ValidationMessages.FIELD_MAX_LENGTH_50)]
        public string? FrecuenciaAnimalSolo { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public string? TieneConocidosEnCasoDeEmergencia { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public string? TieneSalarioAcordeAGastos { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public string? TieneConocidosQueLoAconsejen { get; set; }
    }
}
