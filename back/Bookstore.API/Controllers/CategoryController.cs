using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FluentValidation.Results;
using Bookstore.Domain.DTO;
using Bookstore.Domain.Interfaces.Services;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    [Authorize(Roles = "ADMIN")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCategories([FromQuery(Name = "page")] int page = 1, [FromQuery(Name = "page_size")] int pageSize = 25)
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync(page-1, pageSize);
                var totalCategories = _categoryService.GetCategoriesCount();
                return Ok(new PagedResponseDTO<CategoryDTO>(page, pageSize, totalCategories, $"/v1/categories?", categories));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorMessage = ex.Message,
                    InnerException = ex.InnerException.Message ?? "No Inner Exception"
                });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetCategoryById(long id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                if (category == null)
                    return NotFound();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    ErrorMessage = ex.Message,
                    InnerException = ex.InnerException.Message ?? "No Inner Exception"
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
                    InnerException = ex.InnerException.Message ?? "No Inner Exception"
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
                    InnerException = ex.InnerException.Message ?? "No Inner Exception"
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
                    InnerException = ex.InnerException.Message ?? "No Inner Exception"
                });
            }
        }
    }
}
