using Bookstore.Domain.Entities;
using System.Linq.Expressions;

namespace Bookstore.Domain.Interfaces.Repositories
{
    public interface IBookRepository : ICrudRepository<Book>
    {
        Task<List<Book>> FindAllIncludeCategoryWithFilterAsync(Expression<Func<Book, bool>> filter);

        Task<Book> FindByCodeAsync(int code);
    }
}
