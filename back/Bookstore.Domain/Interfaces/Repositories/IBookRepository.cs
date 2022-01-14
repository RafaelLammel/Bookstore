using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book, long>
    {
        Task<Book> FindByCodeAsync(int code);
    }
}
