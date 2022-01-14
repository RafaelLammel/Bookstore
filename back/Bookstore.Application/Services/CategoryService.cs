using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Bookstore.Domain.DTO;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces.Repositories;
using Bookstore.Domain.Interfaces.Services;

namespace Bookstore.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidator<Category> _categoryValidator;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IValidator<Category> categoryValidator, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _categoryValidator = categoryValidator;
            _mapper = mapper;
        }

        public int GetCategoriesCount()
        {
            return _categoryRepository.Count();
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync(int page, int pageSize)
        {
            var c = await _categoryRepository.FindAllAsync(page, pageSize);
            return _mapper.Map<List<CategoryDTO>>(c);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(long id)
        {
            var c = await _categoryRepository.FindByIdAsync(id);
            return _mapper.Map<CategoryDTO>(c);
        }

        public async Task<ValidationResult> SaveCategoryAsync(CategoryDTO category)
        {
            var c = _mapper.Map<Category>(category);
            ValidationResult validation = await _categoryValidator.ValidateAsync(c);
            if(validation.IsValid)
                await _categoryRepository.SaveAsync(c);
            return validation;
        }

        public async Task<ValidationResult> UpdateCategoryAsync(CategoryDTO category, long id)
        {
            var c = _mapper.Map<Category>(category);
            ValidationResult validation = await _categoryValidator.ValidateAsync(c);
            if(validation.IsValid)
            {
                c.Id = id;
                await _categoryRepository.UpdateAsync(c);
            }
            return validation;
        }

        public async Task DeleteCategoryAsync(long id)
        {
            await _categoryRepository.DeleteByIdCascadeAsync(id);
        }
    }
}
