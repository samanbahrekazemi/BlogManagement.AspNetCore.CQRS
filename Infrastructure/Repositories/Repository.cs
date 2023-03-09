using Core.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class, IEntityBase<TKey>
    {
        private readonly IApplicationDbContext _context;
        public Repository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task<T?> FindByAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<T?> GetByIdAsync(TKey id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id != null && e.Id.Equals(id));
        }
        public async  Task<T?> FindByAsync(TKey id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public IQueryable<T> AsQuerable()
        {
            return _context.Set<T>().AsQueryable();
        }
    }

}
