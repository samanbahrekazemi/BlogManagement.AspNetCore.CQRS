using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
