using CatalogService.Api.Features.Categories.Dto;

namespace CatalogService.Api.Features.Courses.Dtos
{
    public record CourseDto(
        Guid Id,
        string Name,
        string Description,
        string ImageUrl,
        CategoryDto Category,
        Feature Feature,
        decimal Price)
    {
    }
}
