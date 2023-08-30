using Microsoft.EntityFrameworkCore;
using Patitas.Infrastructure.Contracts;
using Patitas.Infrastructure.Enums;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace Patitas.Infrastructure.Repositories
{
    public class Repository<T, K> : IRepository<T, K> where T : class where K : struct
    {
        private readonly PatitasContext _context;

        public Repository(PatitasContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(K id)
        {
            T? result = await _context.Set<T>().FindAsync(id);

            return result;
        }

        public async Task<T?> GetByIdAsync(K id, IncludeTypes includeType, string tableNameProperty = "")
        {
            T? result = await _context.Set<T>().FindAsync(id);

            switch(includeType)
            {
                case IncludeTypes.REFERENCE_TABLE_NAME:
                    await _context.Entry(result!).Reference(tableNameProperty).LoadAsync();
                    break;
                case IncludeTypes.COLLECTION_TABLE_NAME:
                    await _context.Entry(result!).Collection(tableNameProperty).LoadAsync();
                    break;
                default:
                    break;
            }   

            return result;
        }

        public async Task<T?> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
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
