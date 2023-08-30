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
            Usuario usuario = await _repositoryManager.UsuarioRepository.GetUserLoginData(email, password);
            //RolUsuario role = await _repositoryManager.RoleRepository.GetRoleByUser(user.Id);
            
            // Establezco los claims que va a contener el token
            IEnumerable<Claim> claims = this.setClaimsForToken(usuario, usuario.RolUsuario.Nombre);
            // Token listo para ser enviado
            string generatedToken = this.GenerateToken(claims);

            return new LoginResponseDTO()
            {
                Username = usuario.NombreUsuario,
                Email = usuario.Email,
                ProfilePicture = usuario.FotoDePerfil,
                RoleName = usuario.RolUsuario.Nombre,
                TokenAccess = generatedToken
            }; // Esta información es la que va a recibir el navegador
        }

        public async Task<RegisterResponseDTO> Register(RegisterRequestDTO registerData)
        {
            try
            {
                if(await _repositoryManager.UsuarioRepository.ExistsAsync(u => u.Email.Equals(registerData.Email) || u.NombreUsuario.Equals(registerData.Username)))
                    throw new Exception("El email o nombre de usuario ya se encuentra registrado.");

                Usuario usuarioNuevo = new Usuario()
                {
                    NombreUsuario = registerData.Username,
                    Email = registerData.Email,
                    Password = registerData.Password,
                    FechaCreacion = DateTime.Now,
                    Id_Barrio = registerData.BarrioId,
                    Id_RolUsuario = 2
                };

                await _repositoryManager.UsuarioRepository.CreateAsync(usuarioNuevo);

                Usuario? usuario = await _repositoryManager.UsuarioRepository.FindByAsync(x => x.Email.Equals(usuarioNuevo.Email));

                if (usuario != null)
                {
                    Adoptante adoptanteNuevo = new Adoptante() { Id = usuario.Id, Nombre = usuario.NombreUsuario };
                    await _repositoryManager.AdoptanteRepository.CreateAsync(adoptanteNuevo);
                }
                else
                {
                    await _repositoryManager.UsuarioRepository.DeleteAsync(usuarioNuevo);
                    throw new Exception("El adoptante no pudo ser creado. Inténtelo de nuevo.");
                }

                // auto-login
                LoginResponseDTO loginResponse = await this.Login(usuarioNuevo.Email, usuarioNuevo.Password);

                return new RegisterResponseDTO()
                {
                    Message = "¡Registro completado con éxito!",
                    Welcome = $"Bienvenido a Patitas, {usuario.NombreUsuario}",
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
