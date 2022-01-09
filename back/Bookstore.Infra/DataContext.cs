using Microsoft.EntityFrameworkCore;
using Bookstore.Domain.Entities;

namespace Bookstore.Infra
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasIndex(x => x.Code).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
