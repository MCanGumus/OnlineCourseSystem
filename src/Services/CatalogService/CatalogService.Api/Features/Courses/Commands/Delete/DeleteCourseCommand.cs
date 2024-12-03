namespace CatalogService.Api.Features.Courses.Commands.Delete
{
    public record DeleteCourseCommand(Guid Id) : IRequestByServiceResult;
}
