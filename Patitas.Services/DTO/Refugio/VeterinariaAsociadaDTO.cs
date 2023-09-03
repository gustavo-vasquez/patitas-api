﻿using System;
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
        public string Especialidades { get; set; } = string.Empty;
        public DateTime FechaFundacion { get; set; }
        public string? TelefonoAlternativo { get; set; }
        public string? SitioWeb { get; set; }
        public string HorarioApertura { get; set; } = string.Empty;
        public string HorarioCierre { get; set; } = string.Empty;
    }
}