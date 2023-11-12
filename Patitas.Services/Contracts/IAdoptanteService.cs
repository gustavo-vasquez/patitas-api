﻿using Patitas.Services.DTO.Adoptante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Services.Contracts
{
    public interface IAdoptanteService
    {
        Task<AdoptantePerfilCompletoDTO> GetPerfilDelAdoptante(IIdentity? identity);
    }
}
