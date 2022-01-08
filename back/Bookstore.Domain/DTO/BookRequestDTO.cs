namespace Bookstore.Domain.DTO
{
    public class BookRequestDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Pages { get; set; }
        public int Code { get; set; }
        public int CategoryId { get; set; }
    }
}
