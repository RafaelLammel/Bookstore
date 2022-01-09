using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Bookstore.Domain.DTO;
using Bookstore.Domain.Interfaces.Services;

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
        public async Task<ActionResult> GetAllCategories()
        {
            try
            {
                return Ok(await _categoryService.GetAllCategoriesAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorMessage = ex.Message,
                    InnerException = ex.InnerException.Message
                });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(long id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                if (category == null)
                    return NotFound();
                return category;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorMessage = ex.Message,
                    InnerException = ex.InnerException.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SaveCategory([FromBody] CategoryDTO category)
        {
            try
            {
                ValidationResult validation = await _categoryService.SaveCategoryAsync(category);
                if(validation.IsValid)
                    return Created("v1/categories", category);
                return BadRequest(validation.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorMessage = ex.Message,
                    InnerException = ex.InnerException.Message
                });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateCategory([FromBody] CategoryDTO category, long id)
        {
            try
            {
                ValidationResult validation = await _categoryService.UpdateCategoryAsync(category, id);
                if(validation.IsValid)
                    return NoContent();
                return BadRequest(validation.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorMessage = ex.Message,
                    InnerException = ex.InnerException.Message
                });
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> UpdateCategory(long id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorMessage = ex.Message,
                    InnerException = ex.InnerException.Message
                });
            }
        }
    }
}
