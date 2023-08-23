using Project001.Infra.SqlServer.Contexts;
using Project01.Domain.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Infra.SqlServer.Repositories
{
    public abstract class BaseRepository<TEntity, TKey>
        : IRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly SqlServerContext _sqlServerContext;

        protected BaseRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }
      

        public async virtual Task CreateAsync(TEntity entity)
        {
            _sqlServerContext.Set<TEntity>().Add(entity);
            await _sqlServerContext.SaveChangesAsync();
        }

        public async virtual Task UpdateAsync(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            await _sqlServerContext.SaveChangesAsync();
        }


        public Task<TEntity> GetAllAsync(int page, int limit)
        {
            throw new NotImplementedException();
        }


        public async Task DeleteAsync(TEntity entity)
        {
            _sqlServerContext.Set<TEntity>().Remove(entity);
            await _sqlServerContext.SaveChangesAsync();
        }

        public async virtual Task<TEntity> GetByIdAsync(TKey id)
            => await _sqlServerContext.Set<TEntity>().FindAsync(id);
      


        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }
    }
}
