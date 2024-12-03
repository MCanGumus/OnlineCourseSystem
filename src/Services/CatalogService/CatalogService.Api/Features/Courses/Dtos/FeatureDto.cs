namespace CatalogService.Api.Features.Courses.Dtos
{
    public class FeatureDto
    {
        public int Duration { get; set; }
        public float Rating { get; set; }
        public string EducatorName { get; set; } = default!;
    }
}
