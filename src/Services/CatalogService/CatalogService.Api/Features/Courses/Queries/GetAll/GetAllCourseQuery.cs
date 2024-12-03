using CatalogService.Api.Features.Courses.Dtos;

namespace CatalogService.Api.Features.Courses.Queries.GetAll
{
    public record GetAllCourseQuery : IRequestByServiceResult<List<CourseDto>>;
}
