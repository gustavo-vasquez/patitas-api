using Microsoft.EntityFrameworkCore;
using Patitas.Domain.Entities;
using Patitas.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Repositories
{
    internal class UserRepository : Repository<Usuario, int>, IUserRepository
    {
        private readonly PatitasContext _context;
        public UserRepository(PatitasContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUserLoginData(string email, string password)
        {
            try
            {
                Usuario? user = await _context.Usuarios.Include(u => u.RolUsuario).Where(x => x.Email.Equals(email) && x.Password.Equals(password)).FirstOrDefaultAsync();

                if(user is null)
                    throw new ArgumentException("Los datos ingresados son incorrectos.");

                return user;
            }
            catch
            {
                throw;
            }
        }
    }
}
