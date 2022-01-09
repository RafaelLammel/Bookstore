using Bookstore.Domain.Entities;
using System.Linq.Expressions;

namespace Bookstore.Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> FindAllIncludeCategoryWithFilterAsync(Expression<Func<Book, bool>> filter);

        Task<Book> FindByIdAsync(long id);

        Task<Book> FindByIdWithCategoryAsync(long id);

        Task<Book> FindByCodeAsync(int code);

        Task SaveAsync(Book book);

        Task UpdateAsync(Book book);

        Task DeleteAsync(Book book);
    }
}
