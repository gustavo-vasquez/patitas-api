using Patitas.Services.DTO.Barrio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Contracts
{
    public interface IBarrioService
    {
        Task<IEnumerable<BarrioResponseDTO>> GetBarrios();
    }
}
