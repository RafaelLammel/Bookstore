namespace Bookstore.Domain.Interfaces.Repositories
{
    public interface ICrudRepository<T>
    {
        Task<List<T>> FindAllAsync();

        Task<T> FindByIdAsync(long id);

        Task SaveAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
