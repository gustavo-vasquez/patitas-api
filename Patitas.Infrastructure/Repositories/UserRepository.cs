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
    }
}
