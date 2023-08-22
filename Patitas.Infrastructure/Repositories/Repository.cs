using Microsoft.EntityFrameworkCore;
using Patitas.Infrastructure.Contracts;
using System.Reflection.Metadata;

namespace Patitas.Infrastructure.Repositories
{
    public class Repository<T, K> : IRepository<T, K> where T : class where K : class
    {
        private readonly PatitasContext _context;

        public Repository(PatitasContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(K id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> ExistsAsync(K id)
        {
            return await _context.Set<T>().AnyAsync();
        }

        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if(entity != null)
            {
                _context.Set<T>().Remove(entity);
                await SaveAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
