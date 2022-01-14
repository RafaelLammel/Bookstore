using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Bookstore.Domain.Interfaces.Repositories;

namespace Bookstore.Infra.Repositories
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> 
        where TEntity : class 
        where TId : struct
    {
        private readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public int Count()
        {
            return _dataContext.Set<TEntity>().Count();
        }

        public async Task<List<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> filter,
            string[] includeProperties,
            int page,
            int pageSize)
        {
            IQueryable<TEntity> query = _dataContext.Set<TEntity>().Where(filter);
            
            foreach (var property in includeProperties)
                query = query.Include(property);

            return await query.Skip(page).Take(pageSize).ToListAsync();
        }

        public async Task<List<TEntity>> FindAllAsync(int page, int pageSize)
        {
            return await _dataContext.Set<TEntity>().Skip(page).Take(pageSize).ToListAsync();
        }

        public async Task<TEntity> FindByIdAsync(TId id)
        {
            return await _dataContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> FindByIdAsync(TId id, string[] includeProperties)
        {
            var entity = await _dataContext.Set<TEntity>().FindAsync(id);
            
            if(includeProperties != null)
                foreach (var str in includeProperties)
                    await _dataContext.Entry(entity).Reference(str).LoadAsync();
 
            return entity;
        }

        public async Task SaveAsync(TEntity entity)
        {
            _dataContext.Set<TEntity>().Add(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dataContext.Set<TEntity>().Update(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dataContext.Set<TEntity>().Remove(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
