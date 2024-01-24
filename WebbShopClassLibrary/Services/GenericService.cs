using Microsoft.EntityFrameworkCore;
using WebbShopClassLibrary.Context;

namespace WebbShopClassLibrary.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly WebbShopContext _context;
        private readonly DbSet<T> _table;

        public GenericService(WebbShopContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _table.FindAsync(id);
            if (result == null)
            {
                throw new KeyNotFoundException($"Item with ID {id} was not found");
            }
            _context.Entry(result).State = EntityState.Detached;
            return result;
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _table.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            var result = await _table.FindAsync(id);
            if (result == null)
            {
                throw new KeyNotFoundException($"Item with ID {id} was not found");
            }
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var result = await _table.FindAsync(id);
            if (result == null)
            {
                throw new KeyNotFoundException($"Item with ID {id} was not found");
            }
            _table.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
