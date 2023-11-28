namespace Application.Models.Dtos
{
    public class BannerDto
    {
        public int BannerId { get; set; }
        public int BannerType { get; set; }
        public string BannerImage { get; set; }
        public DateTime ActiveFrom { get; set; } = DateTime.MinValue;
        public DateTime ActiveTo { get; set; } = DateTime.MinValue;
        public int? BookId { get; set; }
        public string Url { get; set; }
    }
}
