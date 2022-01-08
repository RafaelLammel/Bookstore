using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces.Repositories;

namespace Bookstore.Infra.Repositories
{
    public class CategoryRepository : CrudRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(DataContext dataContext) : base(dataContext)
        { }
    
    }
}
