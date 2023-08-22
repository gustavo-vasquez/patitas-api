using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patitas.Infrastructure.Contracts
{
    internal interface IRepository<T, K> where T : class where K : class
    {
        Task<T?> GetByIdAsync(K id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> ExistsAsync(K id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
    }
}
