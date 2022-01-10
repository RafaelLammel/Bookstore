using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FluentValidation.Results;
using Bookstore.Domain.DTO;
using Bookstore.Domain.Interfaces.Services;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("v1/books")]
    [Authorize(Roles = "ADMIN")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBooks([FromQuery(Name = "name")] string name,
            [FromQuery(Name = "category")] string category,
            [FromQuery(Name = "min_price")] float minPrice,
            [FromQuery(Name = "max_price")] float maxPrice)
        {
            try
            {
                return Ok(await _bookService.GetAllBooksAsync(name, category, minPrice, maxPrice));
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
        public async Task<ActionResult> GetBookById(long id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);
                if (book == null)
                    return NotFound();
                return Ok(book);
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
        public async Task<ActionResult> SaveBook([FromBody] BookRequestDTO book)
        {
            try
            {
                ValidationResult validation = await _bookService.SaveBookAsync(book);
                if(validation.IsValid)
                    return Created("v1/books", book);
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
        public async Task<ActionResult> UpdateBook([FromBody] BookRequestDTO book, long id)
        {
            try
            {
                ValidationResult validation = await _bookService.UpdateBookAsync(book, id);
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
        public async Task<ActionResult> UpdateBook(long id)
        {
            try
            {
                await _bookService.DeleteBookAsync(id);
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
