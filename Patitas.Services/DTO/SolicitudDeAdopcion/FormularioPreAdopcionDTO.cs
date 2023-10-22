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
        public bool? TuvoMascota { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public bool? TieneMascotas { get; set; }

        [MaxLength(200, ErrorMessage = ValidationMessages.FIELD_MAX_LENGTH_200)]
        public string? DescripcionMascotas { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public bool? ViveSolo { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public bool? TieneVeterinariaCerca { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public bool? ViveEnCasa { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public bool? ViveEnDepartamento { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        [RegularExpression($"^[2-4]*$", ErrorMessage = ValidationMessages.NUMBER_NOT_VALID)]
        public byte? CantidadDeAmbientes { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public bool? TienePatio { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public bool? TieneBalcon { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public bool? TieneRedEnVentanas { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public bool? ConoceLeyDeMaltratoAnimal { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        [MaxLength(50, ErrorMessage = ValidationMessages.FIELD_MAX_LENGTH_50)]
        public string? FrecuenciaAnimalSolo { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public bool? TieneConocidosEnCasoDeEmergencia { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public bool? TieneSalarioAcordeAGastos { get; set; }

        [Required(ErrorMessage = ValidationMessages.FIELD_REQUIRED)]
        public bool? TieneConocidosQueLoAconsejen { get; set; }
    }
}
