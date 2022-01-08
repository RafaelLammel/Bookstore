using AutoMapper;
using Bookstore.Domain.DTO;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces.Repositories;
using Bookstore.Domain.Interfaces.Services;

namespace Bookstore.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
        {
            var c = await _categoryRepository.FindAllAsync();
            return _mapper.Map<List<CategoryDTO>>(c);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(long id)
        {
            var c = await _categoryRepository.FindByIdAsync(id);
            return _mapper.Map<CategoryDTO>(c);
        }

        public async Task SaveCategoryAsync(CategoryDTO category)
        {
            var c = _mapper.Map<Category>(category);
            await _categoryRepository.SaveAsync(c);
        }

        public async Task UpdateCategoryAsync(CategoryDTO category, long id)
        {
            var c = _mapper.Map<Category>(category);
            c.Id = id;
            await _categoryRepository.UpdateAsync(c);
        }

        public async Task DeleteCategoryAsync(long id)
        {
            var c = await _categoryRepository.FindByIdAsync(id);
            await _categoryRepository.DeleteAsync(c);
        }
    }
}
