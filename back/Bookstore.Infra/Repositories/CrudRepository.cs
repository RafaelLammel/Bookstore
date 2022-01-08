using Microsoft.EntityFrameworkCore;
using Bookstore.Domain.Interfaces.Repositories;

namespace Bookstore.Infra.Repositories
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        protected readonly DataContext _dataContext;

        public CrudRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await _dataContext.Set<T>().ToListAsync();
        }

        public async Task<T> FindByIdAsync(long id)
        {
            return await _dataContext.Set<T>().FindAsync(id);
        }

        public async Task SaveAsync(T entity)
        {
            _dataContext.Set<T>().Add(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dataContext.Set<T>().Update(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
