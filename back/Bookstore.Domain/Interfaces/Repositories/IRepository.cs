using System.Linq.Expressions;

namespace Bookstore.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity, TId>
        where TEntity : class
        where TId : struct
    {
        int Count();

        Task<List<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> filter,
            string[] includeProperties,
            int page,
            int pageSize);

        Task<List<TEntity>> FindAllAsync(int page, int pageSize);

        Task<TEntity> FindByIdAsync(TId id);

        Task<TEntity> FindByIdAsync(TId id, string[] includeProperties);

        Task SaveAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}
