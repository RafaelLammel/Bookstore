namespace Bookstore.Domain.Entities
{
    public class Category
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public List<Book> Books { get; set; }
    }
}
