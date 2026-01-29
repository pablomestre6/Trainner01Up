using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project01.Domain.Core.Interfaces
{
    public interface IRepository<TEntity, TKey> : IDisposable
        where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);


        Task<TEntity> GetAllAsync(int page, int limit);
        Task<TEntity> GetByIdAsync(TKey id);
    }
}
