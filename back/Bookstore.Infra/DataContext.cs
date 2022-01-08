using Microsoft.EntityFrameworkCore;
using Bookstore.Domain.Entities;

namespace Bookstore.Infra
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
