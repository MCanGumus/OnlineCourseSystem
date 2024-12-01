using CatalogService.Api.Features.Categories.Commands.Create;
using CatalogService.Api.Features.Courses.Commands.Create;

namespace CatalogService.Api.Features.Courses
{
    public static class CourseEndpointExtension
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/course").WithTags("Courses")
                .CreateCourseGroupItemEndpoint();
        }
    }
}
