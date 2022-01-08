using Bookstore.Domain.DTO;

namespace Bookstore.Domain.Interfaces.Services
{
    public interface IBookService
    {
        Task<List<BookResponseDTO>> GetAllBooksAsync();

        Task<BookResponseDTO> GetBookByIdAsync(long id);

        Task<List<BookResponseDTO>> GetAllBooksByNameAsync(string name);

        Task<BookResponseDTO> GetBookByCodeAsync(int code);

        Task<List<BookResponseDTO>> GetBooksByCategoryAsync(string category);

        Task<List<BookResponseDTO>> GetBooksByPriceRangeAsync(float min, float max);

        Task SaveBookAsync(BookRequestDTO book);

        Task UpdateBookAsync(BookRequestDTO book, long id);

        Task DeleteBookAsync(long id);
    }
}
