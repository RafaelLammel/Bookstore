using Bookstore.Domain.DTO;
using Bookstore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("v1/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<List<BookResponseDTO>> GetAllBooks([FromQuery(Name = "name")] string name,
            [FromQuery(Name = "category")] string category,
            [FromQuery(Name = "min_price")] float minPrice,
            [FromQuery(Name = "max_price")] float maxPrice)
        {
            return await _bookService.GetAllBooksAsync(name, category, minPrice, maxPrice);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<BookResponseDTO>> GetBookById(long id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
                return NotFound();
            return book;
        }

        [HttpPost]
        public async Task<ActionResult> SaveBook([FromBody] BookRequestDTO book)
        {
            await _bookService.SaveBookAsync(book);
            return Created("v1/books", book);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateBook([FromBody] BookRequestDTO book, long id)
        {
            await _bookService.UpdateBookAsync(book, id);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> UpdateBook(long id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
