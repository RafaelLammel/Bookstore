using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Domain.Entities
{
    public class Book
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public float Price { get; set; }
        
        public int Pages { get; set; }
        
        [Index(IsUnique = true)]
        public int Code { get; set; }
        
        public Category Category { get; set; }
    }
}
