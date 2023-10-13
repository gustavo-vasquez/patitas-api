using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts.Manager;
using Patitas.Services.Contracts;
using Patitas.Services.DTO.Login;
using Patitas.Services.DTO.Registro;
using Patitas.Services.DTO.Registro.Roles;
using Patitas.Services.Helpers;
using Patitas.Services.Helpers.Enums;
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

        public async Task<LoginResponseDTO?> Login(string email, string password)
        {
            try
            {
                Usuario? usuario = await _repositoryManager.UsuarioRepository.GetUserLoginData(email, password);

                if (usuario is null)
                    return null;
            
                // Establezco los claims que va a contener el token
                IEnumerable<Claim> claims = this.setClaimsForToken(usuario, usuario.RolUsuario.Nombre);
                // Token listo para ser enviado
                string generatedToken = this.GenerateToken(claims);

                return new LoginResponseDTO()
                {
                    NombreDeUsuario = usuario.NombreUsuario,
                    Email = usuario.Email,
                    FotoDePerfil = usuario.FotoDePerfil,
                    Rol = usuario.RolUsuario.Nombre,
                    AccessToken = generatedToken
                }; // Esta información es la que va a recibir el navegador
            }
            catch
            {
                throw new Exception("Ha ocurrido un error inesperado. Vuelva a intentarlo.");
            }
        }

        public async Task<RegistroResponseDTO> RegistrarCuenta(RegistroRequestDTO datosDeRegistro, RolTypes rolSeleccionado)
        {
            Usuario? usuarioNuevo = null;

            try
            {
                if (await _repositoryManager.UsuarioRepository.ExistsAsync(u => u.Email.Equals(datosDeRegistro.Email) || u.NombreUsuario.Equals(datosDeRegistro.NombreDeUsuario)))
                    throw new Exception("El email o nombre de usuario ya se encuentra registrado.");

                usuarioNuevo = new Usuario()
                {
                    NombreUsuario = datosDeRegistro.NombreDeUsuario,
                    Email = datosDeRegistro.Email,
                    Password = datosDeRegistro.Password,
                    Telefono = datosDeRegistro.Telefono,
                    Direccion = datosDeRegistro.Calle != null && datosDeRegistro.Altura != null ? string.Join(' ', datosDeRegistro.Calle, datosDeRegistro.Altura) : null,
                    FechaCreacion = DateTime.Now,
                    Id_Barrio = datosDeRegistro.Id_Barrio,
                    Id_Rol = (int)rolSeleccionado
                };

                await _repositoryManager.UsuarioRepository.CreateAsync(usuarioNuevo);

                // Busco el id de usuario recién creado para asignarselo a la tabla (Adoptante/Refugio/Veterinaria) que voy a crear
                Usuario? usuario = await _repositoryManager.UsuarioRepository.FindByAsync(x => x.Email.Equals(usuarioNuevo.Email));

                if (usuario != null)
                {
                    switch (rolSeleccionado)
                    {
                        case RolTypes.ADOPTANTE:
                            Adoptante adoptanteNuevo = this.GenerarAdoptante(datosDeRegistro, usuario);
                            await _repositoryManager.AdoptanteRepository.CreateAsync(adoptanteNuevo);
                            break;
                        case RolTypes.REFUGIO:
                            Refugio refugioNuevo = this.GenerarRefugio(datosDeRegistro, usuario);
                            await _repositoryManager.RefugioRepository.CreateAsync(refugioNuevo);
                            break;
                        case RolTypes.VETERINARIA:
                            Veterinaria veterinariaNueva = this.GenerarVeterinaria(datosDeRegistro, usuario);
                            await _repositoryManager.VeterinariaRepository.CreateAsync(veterinariaNueva);
                            break;
                        default:
                            throw new Exception("El tipo de usuario no existe.");
                    }
                }
                else
                {
                    throw new Exception("El usuario no pudo ser creado.");
                }

                // auto-login
                LoginResponseDTO? loginResponse = await this.Login(usuarioNuevo.Email, usuarioNuevo.Password);

                return new RegistroResponseDTO()
                {
                    Resultado = "¡Registro completado con éxito!",
                    Bienvenida = $"Bienvenido a Patitas, {usuario.NombreUsuario}",
                    LoginResponse = loginResponse
                };
            }
            catch
            {
                /* si después de crear un registro en la tabla Usuario ocurrió un error y, además no se llegó a crear un registro en la tabla
                (adoptante/refugio/veterinaria), hago un rollback eliminando ese usuario creado que quedaría huérfano
                porque no estaría asignado a ningún rol de usuario */
                if(usuarioNuevo != null)
                    await _repositoryManager.UsuarioRepository.DeleteAsync(usuarioNuevo);

                throw new Exception("Se produjo un error inesperado al crear la cuenta. Inténtelo de nuevo.");
            }
        }

        private Adoptante GenerarAdoptante<T>(T dto, Usuario usuario) where T : class
        {
            if(dto is RegistroAdoptanteDTO datosDeRegistro)
            {
                Adoptante adoptanteNuevo = new Adoptante()
                {
                    Id = usuario.Id,
                    Nombre = usuario.NombreUsuario,
                    FechaNacimiento = datosDeRegistro.FechaDeNacimiento
                };

                return adoptanteNuevo;
            }

            throw new Exception($"El usuario de tipo {nameof(Adoptante)} no pudo ser generado.");
        }

        private Refugio GenerarRefugio<T>(T dto, Usuario usuario) where T : class
        {
            if (dto is RegistroRefugioDTO datosDeRegistro)
            {
                Refugio refugioNuevo = new Refugio()
                {
                    Id = usuario.Id,
                    Nombre = datosDeRegistro.Nombre,
                    RazonSocial = datosDeRegistro.RazonSocial,
                    NombreResponsable = datosDeRegistro.NombreResponsable,
                    ApellidoResponsable = datosDeRegistro.ApellidoResponsable,
                    DiasDeAtencion = datosDeRegistro.DiasDeAtencion,
                    HorarioApertura = datosDeRegistro.HoraApertura,
                    HorarioCierre = datosDeRegistro.HoraCierre
                };

                return refugioNuevo;
            }

            throw new Exception($"El usuario de tipo {nameof(Refugio)} no pudo ser generado.");
        }

        private Veterinaria GenerarVeterinaria<T>(T dto, Usuario usuario) where T : class
        {
            if (dto is RegistroVeterinariaDTO datosDeRegistro)
            {
                Veterinaria veterinariaNueva = new Veterinaria()
                {
                    Id = usuario.Id,
                    Nombre = datosDeRegistro.Nombre,
                    RazonSocial = datosDeRegistro.RazonSocial,
                    Especialidades = datosDeRegistro.Especialidades,
                    FechaFundacion = datosDeRegistro.FechaFundacion,
                    TelefonoAlternativo = datosDeRegistro.TelefonoAlternativo,
                    DiasDeAtencion = datosDeRegistro.DiasDeAtencion,
                    HorarioApertura = datosDeRegistro.HoraApertura,
                    HorarioCierre = datosDeRegistro.HoraCierre
                };

                return veterinariaNueva;
            }

            throw new Exception($"El usuario de tipo {nameof(Veterinaria)} no pudo ser generado.");
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
