
namespace Application.Dto.DTOs
{
    public class ProductSearchDto
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string OrderBy { get; set; } = "Name";
        public string SortBy { get; set; } = "asc";
    }
}
