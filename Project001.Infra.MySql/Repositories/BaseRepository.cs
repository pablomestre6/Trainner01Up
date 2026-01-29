using Microsoft.EntityFrameworkCore;

namespace Project001.Infra.MySql.Repositories
{
    public abstract class BaseRepository<TEntity, TKey>
        where TEntity : class
    {
        protected readonly DbContext Context;

        protected BaseRepository(DbContext context)
        {
            Context = context;
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAllAsync(int page, int limit)
        {
            return await Context.Set<TEntity>()
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();
        }
    }
}
