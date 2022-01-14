using Microsoft.EntityFrameworkCore;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces.Repositories;

namespace Bookstore.Infra.Repositories
{
    public class CategoryRepository : Repository<Category, long>, ICategoryRepository
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task DeleteByIdCascadeAsync(long id)
        {
            var c = await _dataContext.Categories.Include(x => x.Books).Where(x => x.Id == id).FirstOrDefaultAsync();
            _dataContext.Remove(c);
            await _dataContext.SaveChangesAsync();
        }
    }
}
