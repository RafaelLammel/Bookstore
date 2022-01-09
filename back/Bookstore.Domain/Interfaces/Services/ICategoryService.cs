using FluentValidation.Results;
using Bookstore.Domain.DTO;

namespace Bookstore.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategoriesAsync();

        Task<CategoryDTO> GetCategoryByIdAsync(long id);

        Task<ValidationResult> SaveCategoryAsync(CategoryDTO category);

        Task<ValidationResult> UpdateCategoryAsync(CategoryDTO category, long id);

        Task DeleteCategoryAsync(long id);
    }
}
