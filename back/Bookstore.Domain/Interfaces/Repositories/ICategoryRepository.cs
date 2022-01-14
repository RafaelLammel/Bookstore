using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category, long>
    {
        Task DeleteByIdCascadeAsync(long id);
    }
}
