using AutoMapper;
using Bookstore.Domain.DTO;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces.Repositories;
using Bookstore.Domain.Interfaces.Services;

namespace Bookstore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<BookResponseDTO>> GetAllBooksAsync()
        {
            var b = await _bookRepository.FindAllAsync();
            return _mapper.Map<List<BookResponseDTO>>(b);
        }

        public async Task<BookResponseDTO> GetBookByIdAsync(long id)
        {
            var b = await _bookRepository.FindByIdAsync(id);
            return _mapper.Map<BookResponseDTO>(b);
        }

        public async Task<List<BookResponseDTO>> GetAllBooksByNameAsync(string name)
        {
            var b = await _bookRepository.FindAllByNameAsync(name);
            return _mapper.Map<List<BookResponseDTO>>(b);
        }

        public async Task<BookResponseDTO> GetBookByCodeAsync(int code)
        {
            var b = await _bookRepository.FindByCodeAsync(code);
            return _mapper.Map<BookResponseDTO>(b);
        }

        public async Task<List<BookResponseDTO>> GetBooksByCategoryAsync(string category)
        {
            var b = await _bookRepository.FindAllByCategoryAsync(category);
            return _mapper.Map<List<BookResponseDTO>>(b);
        }

        public async Task<List<BookResponseDTO>> GetBooksByPriceRangeAsync(float min, float max)
        {
            var b = await _bookRepository.FindAllByPriceRangeAsync(min, max);
            return _mapper.Map<List<BookResponseDTO>>(b);
        }

        public async Task SaveBookAsync(BookRequestDTO book)
        {
            var b = _mapper.Map<Book>(book);
            var c = await _categoryRepository.FindByIdAsync(book.CategoryId);
            b.Category = c;
            await _bookRepository.SaveAsync(b);
        }

        public async Task UpdateBookAsync(BookRequestDTO book, long id)
        {
            var b = _mapper.Map<Book>(book);
            var c = await _categoryRepository.FindByIdAsync(book.CategoryId);
            b.Id = id;
            b.Category = c;
            await _bookRepository.UpdateAsync(b);
        }

        public async Task DeleteBookAsync(long id)
        {
            var b = await _bookRepository.FindByIdAsync(id);
            await _bookRepository.DeleteAsync(b);
        }
    }
}
