using Patitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Contracts
{
    public interface IUsuarioRepository : IRepository<Usuario, int>
    {
        Task<Usuario> GetUserLoginData(string email, string password);
    }
}
