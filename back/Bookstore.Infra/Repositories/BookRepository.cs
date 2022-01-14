using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infra.Repositories
{
    public class BookRepository : Repository<Book, long>, IBookRepository
    {
        private readonly DataContext _dataContext;

        public BookRepository(DataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Book> FindByCodeAsync(int code)
        {
            return await _dataContext.Books.Where(x => x.Code == code).FirstOrDefaultAsync();
        }
    }
}
