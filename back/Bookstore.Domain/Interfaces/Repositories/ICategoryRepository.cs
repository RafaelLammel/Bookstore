using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> FindAllAsync();

        Task<Category> FindByIdAsync(long id);

        Task SaveAsync(Category category);

        Task UpdateAsync(Category category);

        Task DeleteByIdCascadeAsync(long id);
    }
}
