using Core.Common;
using Core.Interfaces;
using System.Linq.Expressions;

namespace Infrastructure.Interfaces
{
    public interface IRepository<T, TKey> where T : class, IEntityBase<TKey>
    {
        IQueryable<T> AsQuerable();
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetByIdAsync(TKey id);
        Task<T?> FindByAsync(TKey id);
        Task<T> UpdateAsync(T entity);
    }
}
