using Bookstore.Domain.DTO;

namespace Bookstore.Domain.Interfaces.Services
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooksAsync();

        Task<BookDTO> GetBookByIdAsync(long id);

        Task<List<BookDTO>> GetAllBooksByNameAsync(string name);

        Task<BookDTO> GetBookByCodeAsync(int code);

        Task<List<BookDTO>> GetBooksByCategoryAsync(string category);

        Task<List<BookDTO>> GetBooksByPriceRangeAsync(float min, float max);

        Task SaveBookAsync(BookDTO book);

        Task UpdateBookAsync(BookDTO book, long id);

        Task DeleteBookAsync(long id);
    }
}
