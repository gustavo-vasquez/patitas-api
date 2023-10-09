using Patitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.DTO.Refugio
{
    public class ExplorarRefugiosDTO
    {
        public List<string> Barrios { get; internal set; } = new List<string>();
        public List<RefugioDTO> Refugios { get; internal set; } = new List<RefugioDTO>();
    }
}
