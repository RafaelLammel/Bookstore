using FluentValidation;
using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
