using Patitas.Services.DTO.Login;
using Patitas.Services.DTO.Registro;
using Patitas.Services.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<LoginResponseDTO?> Login(string email, string password);
        Task<RegistroResponseDTO> RegistrarCuenta(RegistroRequestDTO datosDeRegistro, RolTypes rolSeleccionado);
    }
}
