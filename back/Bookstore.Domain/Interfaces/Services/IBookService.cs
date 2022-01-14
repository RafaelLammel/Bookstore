using FluentValidation.Results;
using Bookstore.Domain.DTO;

namespace Bookstore.Domain.Interfaces.Services
{
    public interface IBookService
    {
        int GetBooksCount();

        #nullable enable
        Task<List<BookResponseDTO>> GetAllBooksAsync(string? name, string? category, float? minPrice, float? maxPrice, int skip = 0, int take = 0);
        #nullable disable

        Task<BookResponseDTO> GetBookByIdAsync(long id);

        Task<BookResponseDTO> GetBookByCodeAsync(int code);

        Task<ValidationResult> SaveBookAsync(BookRequestDTO book);

        Task<ValidationResult> UpdateBookAsync(BookRequestDTO book, long id);

        Task DeleteBookAsync(long id);
    }
}
