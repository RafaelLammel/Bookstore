namespace Bookstore.Domain.Entities
{
    public class Book
    {
        public long Id { get; set; }

        public string Name { get; set; }
        
        public float Price { get; set; }
        
        public int Pages { get; set; }
        
        public int Code { get; set; }
        
        public long CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
