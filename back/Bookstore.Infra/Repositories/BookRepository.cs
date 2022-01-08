using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces.Repositories;
using System.Data.Entity;

namespace Bookstore.Infra.Repositories
{
    public class BookRepository : CrudRepository<Book>, IBookRepository
    {

        public BookRepository(DataContext dataContext) : base(dataContext)
        { }

        public async Task<List<Book>> FindAllByCategoryAsync(string category)
        {
            return await _dataContext.Books.Where(x => x.Category.Name == category).ToListAsync();
        }

        public async Task<List<Book>> FindAllByNameAsync(string name)
        {
            return await _dataContext.Books.Where(x => x.Name == name).ToListAsync();
        }

        public async Task<List<Book>> FindAllByPriceRangeAsync(float min, float max)
        {
            return await _dataContext.Books.Where(x => x.Price >= min && x.Price <= max).OrderBy(x => x.Price).ToListAsync();
        }

        public async Task<Book> FindByCodeAsync(int code)
        {
            return await _dataContext.Books.Where(x => x.Code == code).FirstOrDefaultAsync();
        }
    }
}
