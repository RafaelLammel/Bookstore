using Bookstore.Domain.DTO;
using Bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            return await _categoryService.GetAllCategoriesAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(long id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound();
            return category;
        }

        [HttpPost]
        public async Task<ActionResult> SaveCategory([FromBody] CategoryDTO category)
        {
            await _categoryService.SaveCategoryAsync(category);
            return Created("v1/categories", category);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateCategory([FromBody] CategoryDTO category, long id)
        {
            await _categoryService.UpdateCategoryAsync(category, id);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> UpdateCategory(long id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
