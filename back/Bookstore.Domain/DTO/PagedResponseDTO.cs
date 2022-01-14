namespace Bookstore.Domain.DTO
{
    public class PagedResponseDTO<T> where T : class
    {
        public string PreviousPage { get; set; }
        public string NextPage { get; set; }
        public List<T> Data { get; set; }

        public PagedResponseDTO(int page, int pageSize, int totalCount, string endpoint, List<T> data)
        {
            if ((page) * pageSize < totalCount)
                NextPage = $"{endpoint}&page={page}&page_size={pageSize}";
            if (page > 1)
                PreviousPage = $"{endpoint}&page={page}&page_size={pageSize}";
            Data = data;
        }
    }
}
