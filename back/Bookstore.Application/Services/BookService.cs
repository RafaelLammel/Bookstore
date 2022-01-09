using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Bookstore.Domain.DTO;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces.Repositories;
using Bookstore.Domain.Interfaces.Services;

namespace Bookstore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IValidator<Book> _bookValidator;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IValidator<Book> bookValidator, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _bookValidator = bookValidator;
            _mapper = mapper;
        }

        #nullable enable
        public async Task<List<BookResponseDTO>> GetAllBooksAsync(string? name, string? category, float? minPrice, float? maxPrice)
        {
            var b = await _bookRepository.FindAllIncludeCategoryWithFilterAsync(
                x => (name != null ? name == x.Name : true)
                && (category != null ? category == x.Category.Name : true)
                && (maxPrice != 0 ? maxPrice >= x.Price : true)
                && (minPrice != 0 ? minPrice <= x.Price : true)
            );
            return _mapper.Map<List<BookResponseDTO>>(b);
        }
        #nullable disable

        public async Task<BookResponseDTO> GetBookByIdAsync(long id)
        {
            var b = await _bookRepository.FindByIdWithCategoryAsync(id);
            return _mapper.Map<BookResponseDTO>(b);
        }

        public async Task<BookResponseDTO> GetBookByCodeAsync(int code)
        {
            var b = await _bookRepository.FindByCodeAsync(code);
            return _mapper.Map<BookResponseDTO>(b);
        }

        public async Task<ValidationResult> SaveBookAsync(BookRequestDTO book)
        {
            var b = _mapper.Map<Book>(book);
            ValidationResult validation = await _bookValidator.ValidateAsync(b);
            if (validation.IsValid)
                await _bookRepository.SaveAsync(b);
            return validation;
        }

        public async Task<ValidationResult> UpdateBookAsync(BookRequestDTO book, long id)
        {
            var b = _mapper.Map<Book>(book);
            ValidationResult validation = await _bookValidator.ValidateAsync(b);
            if (validation.IsValid)
            {
                b.Id = id;
                await _bookRepository.UpdateAsync(b);
            }
            return validation;
        }

        public async Task DeleteBookAsync(long id)
        {
            var b = await _bookRepository.FindByIdAsync(id);
            await _bookRepository.DeleteAsync(b);
        }
    }
}
