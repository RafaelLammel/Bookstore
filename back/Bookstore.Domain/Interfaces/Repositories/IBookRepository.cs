using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces.Repositories
{
    public interface IBookRepository : ICrudRepository<Book>
    {
        Task<List<Book>> FindAllByNameAsync(string name);

        Task<Book> FindByCodeAsync(int code);

        Task<List<Book>> FindAllByCategoryAsync(string category);

        Task<List<Book>> FindAllByPriceRangeAsync(float min, float max);
    }
}
