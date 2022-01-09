using FluentValidation;
using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Pages).GreaterThan(0);
            RuleFor(x => x.Code).GreaterThan(0);
            RuleFor(x => x.CategoryId).NotNull();
        }
    }
}
