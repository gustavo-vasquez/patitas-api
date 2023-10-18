using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Validations
{
    internal sealed class ValidationMessages
    {
        public const string FIELD_REQUIRED = "Este campo es obligatorio.";
        public const string FIELD_MAX_LENGTH_50 = "Máximo 50 caracteres.";
        public const string FIELD_MAX_LENGTH_200 = "Máximo 200 caracteres.";
        public const string NUMBER_NOT_VALID = "Número no válido.";
    }
}
