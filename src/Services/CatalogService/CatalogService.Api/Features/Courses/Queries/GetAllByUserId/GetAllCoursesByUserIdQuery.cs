using CatalogService.Api.Features.Courses.Dtos;

namespace CatalogService.Api.Features.Courses.Queries.GetAllByUserId
{
    public record GetAllCoursesByUserIdQuery(Guid UserId) : IRequestByServiceResult<List<CourseDto>>;
}
