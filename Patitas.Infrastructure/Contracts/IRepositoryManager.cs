using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }
        IAdopterRepository AdopterRepository { get; }
    }
}
