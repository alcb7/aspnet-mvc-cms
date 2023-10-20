namespace Cms.Web.Api.DTOs
{
    public class BlogResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int BlogCategoryId { get; set; }
        public string? ResimDosyaAdi { get; set; }
        public string? ResimYolu => ResimDosyaAdi is null ? null : "/images/" + ResimDosyaAdi;

        public IEnumerable<CommentResponseDto>? Comments { get; set; }
    }
}
