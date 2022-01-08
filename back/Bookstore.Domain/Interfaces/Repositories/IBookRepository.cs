using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces.Repositories
{
    public interface IBookRepository : ICrudRepository<Book>
    {
        Task<List<Book>> FindAllByNameAsync(string name);

        Task<Book> FindByCodeAsync(int code);

        Task<List<Book>> FindByCategoryAsync(string category);

        Task<List<Book>> FindByPriceRangeAsync(float min, float max);
    }
}
