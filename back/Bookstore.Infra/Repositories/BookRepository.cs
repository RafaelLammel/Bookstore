using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bookstore.Infra.Repositories
{
    public class BookRepository : CrudRepository<Book>, IBookRepository
    {

        public BookRepository(DataContext dataContext) : base(dataContext)
        { }

        public async Task<List<Book>> FindAllIncludeCategoryWithFilterAsync(Expression<Func<Book, bool>> filter)
        {
            return await _dataContext.Books.Include(x => x.Category).Where(filter).ToListAsync();
        }

        public async Task<Book> FindByCodeAsync(int code)
        {
            return await _dataContext.Books.Where(x => x.Code == code).FirstOrDefaultAsync();
        }
    }
}
