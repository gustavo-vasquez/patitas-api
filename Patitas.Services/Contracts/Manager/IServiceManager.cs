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
        IAdopterService AdopterService { get; }
    }
}
