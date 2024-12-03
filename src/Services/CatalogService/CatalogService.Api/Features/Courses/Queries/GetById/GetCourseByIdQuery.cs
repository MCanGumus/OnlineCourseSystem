using CatalogService.Api.Features.Courses.Dtos;

namespace CatalogService.Api.Features.Courses.Queries.GetById
{
    public record GetCourseByIdQuery(Guid Id) : IRequestByServiceResult<CourseDto>;
}
