using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bookstore.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _dataContext;

        public BookRepository(DataContext dataContext)
        { 
            _dataContext = dataContext;
        }

        public async Task<List<Book>> FindAllIncludeCategoryWithFilterAsync(Expression<Func<Book, bool>> filter)
        {
            return await _dataContext.Books.Include(x => x.Category).Where(filter).ToListAsync();
        }
        public async Task<Book> FindByIdAsync(long id)
        {
            return await _dataContext.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Book> FindByIdWithCategoryAsync(long id)
        {
            return await _dataContext.Books.Include(x => x.Category).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Book> FindByCodeAsync(int code)
        {
            return await _dataContext.Books.Where(x => x.Code == code).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(Book book)
        {
            _dataContext.Books.Add(book);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _dataContext.Books.Update(book);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            _dataContext.Remove(book);
            await _dataContext.SaveChangesAsync();
        }
    }
}
