using Microsoft.EntityFrameworkCore;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces.Repositories;

namespace Bookstore.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;
        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<List<Category>> FindAllAsync()
        {
            return _dataContext.Categories.ToListAsync();
        }

        public async Task<Category> FindByIdAsync(long id)
        {
            return await _dataContext.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task SaveAsync(Category category)
        {
            _dataContext.Categories.Add(category);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _dataContext.Categories.Update(category);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteByIdCascadeAsync(long id)
        {
            var c = await _dataContext.Categories.Include(x => x.Books).Where(x => x.Id == id).FirstOrDefaultAsync();
            _dataContext.Remove(c);
            await _dataContext.SaveChangesAsync();
        }
    }
}
