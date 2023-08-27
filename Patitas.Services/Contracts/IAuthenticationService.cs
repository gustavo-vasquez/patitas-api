using Patitas.Services.DTO.Login;
using Patitas.Services.DTO.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<LoginResponseDTO> Login(string email, string password);
        Task<RegisterResponseDTO> Register(RegisterRequestDTO registerData);
    }
}
