using Bookstore.Domain.DTO;

namespace Bookstore.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllBooksAsync();

        Task<CategoryDTO> GetBookByIdAsync(long id);

        Task SaveBookAsync(CategoryDTO category);

        Task UpdateBookAsync(CategoryDTO category, long id);

        Task DeleteBookAsync(long id);
    }
}
