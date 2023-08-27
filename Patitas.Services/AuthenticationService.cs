using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Services.Contracts;
using Patitas.Services.DTO.Login;
using Patitas.Services.DTO.Register;
using Patitas.Services.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly TokenManagement _tokenManagement;

        public AuthenticationService(IRepositoryManager repositoryManager, IOptions<TokenManagement> tokenManagement)
        {
            _repositoryManager = repositoryManager;
            _tokenManagement = tokenManagement.Value;
        }

        public async Task<LoginResponseDTO> Login(string email, string password)
        {
            Usuario user = await _repositoryManager.UserRepository.GetUserLoginData(email, password);
            //RolUsuario role = await _repositoryManager.RoleRepository.GetRoleByUser(user.Id);
            
            // Establezco los claims que va a contener el token
            IEnumerable<Claim> claims = this.setClaimsForToken(user, user.RolUsuario.Nombre);
            // Token listo para ser enviado
            string generatedToken = this.GenerateToken(claims);

            return new LoginResponseDTO()
            {
                Username = user.NombreUsuario,
                Email = user.Email,
                ProfilePicture = user.FotoDePerfil,
                RoleName = user.RolUsuario.Nombre,
                TokenAccess = generatedToken
            }; // Esta información es la que va a recibir el navegador
        }

        public async Task<RegisterResponseDTO> Register(RegisterRequestDTO registerData)
        {
            try
            {
                if(await _repositoryManager.UserRepository.ExistsAsync(u => u.Email.Equals(registerData.Email) || u.NombreUsuario.Equals(registerData.Username)))
                    throw new Exception("El email o nombre de usuario ya se encuentra registrado.");

                Usuario newUser = new Usuario()
                {
                    NombreUsuario = registerData.Username,
                    Email = registerData.Email,
                    Password = registerData.Password,
                    FechaCreacion = DateTime.Now,
                    Id_Barrio = registerData.BarrioId,
                    Id_RolUsuario = 2
                };

                await _repositoryManager.UserRepository.CreateAsync(newUser);

                Usuario? user = await _repositoryManager.UserRepository.FindByAsync(x => x.Email.Equals(newUser.Email));

                if (user != null)
                {
                    Adoptante newAdopter = new Adoptante() { Id = user.Id, Nombre = user.NombreUsuario };
                    await _repositoryManager.AdopterRepository.CreateAsync(newAdopter);
                }
                else
                {
                    await _repositoryManager.UserRepository.DeleteAsync(newUser);
                    throw new Exception("El adoptante no pudo ser creado. Inténtelo de nuevo.");
                }

                // auto-login
                LoginResponseDTO loginResponse = await this.Login(newUser.Email, newUser.Password);

                return new RegisterResponseDTO()
                {
                    Message = "¡Registro completado con éxito!",
                    Welcome = $"Bienvenido a Patitas, {user.NombreUsuario}",
                    LoginResponse = loginResponse
                };
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrió un error al crear el usuario. Inténtelo de nuevo. \nCausa: " + ex.Message);
            }
        }

        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.KeySecret));

            var token = new JwtSecurityToken
            (
                issuer: _tokenManagement.Issuer,
                audience: _tokenManagement.Audience,
                expires: DateTime.Now.AddMinutes(_tokenManagement.ValidityInMinutes),
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private IEnumerable<Claim> setClaimsForToken(Usuario user, string role)
        {
            IEnumerable<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.NombreUsuario),
                new Claim(ClaimTypes.Role, role),
                new Claim("issued_at", DateTime.Now.ToString())
            };

            return claims;
        }
    }
}
