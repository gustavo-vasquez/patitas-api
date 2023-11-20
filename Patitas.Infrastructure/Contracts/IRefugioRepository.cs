﻿using Patitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Contracts
{
    public interface IRefugioRepository : IRepository<Refugio, int>
    {
        Task<IEnumerable<string>> GetVeterinariasHabilitadas(int refugioId);
    }
}
