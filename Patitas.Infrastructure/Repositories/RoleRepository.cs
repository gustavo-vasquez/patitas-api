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
    internal class RoleRepository : Repository<RolUsuario, int>, IRoleRepository
    {
        private readonly PatitasContext _context;

        public RoleRepository(PatitasContext context) : base(context)
        {
            _context = context;
        }
    }
}
