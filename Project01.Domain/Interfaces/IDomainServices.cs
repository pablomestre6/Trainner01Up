using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01.Domain.Core.Interfaces
{
    public interface IDomainServices<TEntity, TKey> : IDisposable
        where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

        Task<List<TEntity>> GettAllAsync(int page, int limit);
        Task<TEntity> GetByIdAsync(TKey id);
    }
}
