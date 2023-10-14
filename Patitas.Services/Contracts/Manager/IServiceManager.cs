using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Contracts.Manager
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IAdoptanteService AdoptanteService { get; }
        IRefugioService RefugioService { get; }
        IVeterinariaService VeterinariaService { get; }
        IComentarioService ComentarioService { get; }
        IAnimalService AnimalService { get; }
        IBarrioService BarrioService { get; }
    }
}
