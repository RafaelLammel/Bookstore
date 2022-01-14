using FluentValidation.Results;
using Bookstore.Domain.DTO;

namespace Bookstore.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        int GetCategoriesCount();

        Task<List<CategoryDTO>> GetAllCategoriesAsync(int page, int pageSize);

        Task<CategoryDTO> GetCategoryByIdAsync(long id);

        Task<ValidationResult> SaveCategoryAsync(CategoryDTO category);

        Task<ValidationResult> UpdateCategoryAsync(CategoryDTO category, long id);

        Task DeleteCategoryAsync(long id);
    }
}
