using Bookstore.Domain.DTO;

namespace Bookstore.Domain.Interfaces.Services
{
    public interface IBookService
    {
        #nullable enable
        Task<List<BookResponseDTO>> GetAllBooksAsync(string? name, string? category, float? minPrice, float? maxPrice);
        #nullable disable

        Task<BookResponseDTO> GetBookByIdAsync(long id);

        Task<BookResponseDTO> GetBookByCodeAsync(int code);

        Task SaveBookAsync(BookRequestDTO book);

        Task UpdateBookAsync(BookRequestDTO book, long id);

        Task DeleteBookAsync(long id);
    }
}
