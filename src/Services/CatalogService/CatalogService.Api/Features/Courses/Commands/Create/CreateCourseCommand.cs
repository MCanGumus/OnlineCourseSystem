namespace CatalogService.Api.Features.Courses.Commands.Create
{
    public record CreateCourseCommand(
        string Name,
        string Description,
        decimal Price,
        string ImageUrl,
        Guid CategoryId) : IRequestByServiceResult<CreateCourseCommandResponse>
    {
    }
}
