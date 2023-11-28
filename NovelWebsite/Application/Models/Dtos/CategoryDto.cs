namespace Application.Models.Dtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryImage { get; set; }
        public int Quantity { get; set; } = 0;
        public string? Slug { get; set; }
    }
}
