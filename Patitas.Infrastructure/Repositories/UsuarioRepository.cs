using Microsoft.EntityFrameworkCore;
using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    internal class UsuarioRepository : Repository<Usuario, int>, IUsuarioRepository
    {
        private readonly PatitasContext _context;
        public UsuarioRepository(PatitasContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetUserLoginData(string email, string password)
        {
            try
            {
                Usuario? user = await _context.Usuarios.Include(u => u.RolUsuario).Include(u => u.Barrio).Where(x => x.Email.Equals(email) && x.Password.Equals(password)).FirstOrDefaultAsync();

                return user;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> GetUserLoggedId(IIdentity? identity)
        {
            // verifico si el usuario es válido
            if (identity is null || !identity.IsAuthenticated)
                throw new UnauthorizedAccessException("No tiene los permisos para esta acción.");

            // obtengo el id del usuario que estaba en el token
            ClaimsIdentity? claimsIdentity = identity as ClaimsIdentity;
            int userId = Convert.ToInt32(claimsIdentity!.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            // verifico si el id del usuario existe
            if (!await _context.Usuarios.AnyAsync(u => u.Id.Equals(userId)))
                throw new ArgumentException("El usuario no existe.");

            return userId;
        }
    }
}
