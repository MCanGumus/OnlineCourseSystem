using CatalogService.Api.Features.Categories.Commands.Create;
using CatalogService.Api.Features.Courses.Commands.Create;
using CatalogService.Api.Features.Courses.Commands.Delete;
using CatalogService.Api.Features.Courses.Commands.Update;
using CatalogService.Api.Features.Courses.Queries.GetAll;
using CatalogService.Api.Features.Courses.Queries.GetById;

namespace CatalogService.Api.Features.Courses
{
    public static class CourseEndpointExtension
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/course").WithTags("Courses")
                .CreateCourseGroupItemEndpoint()
                .GetAllCourseGroupItemEndpoint()
                .GetCourseByIdGroupItemEndpoint()
                .UpdateCourseGroupItemEndpoint()
                .DeleteCourseGroupItemEndpoint();
        }
    }
}
