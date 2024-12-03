using Asp.Versioning.Builder;
using CatalogService.Api.Features.Categories.Commands.Create;
using CatalogService.Api.Features.Courses.Commands.Create;
using CatalogService.Api.Features.Courses.Commands.Delete;
using CatalogService.Api.Features.Courses.Commands.Update;
using CatalogService.Api.Features.Courses.Queries.GetAll;
using CatalogService.Api.Features.Courses.Queries.GetAllByUserId;
using CatalogService.Api.Features.Courses.Queries.GetById;

namespace CatalogService.Api.Features.Courses
{
    public static class CourseEndpointExtension
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/courses").WithTags("Courses")
                .WithApiVersionSet(apiVersionSet)
                .GetAllCourseGroupItemEndpoint()
                .GetCourseByIdGroupItemEndpoint()
                .UpdateCourseGroupItemEndpoint()
                .DeleteCourseGroupItemEndpoint()
                .GetCoursesByUserIdGroupItemEndpoint();
        }
    }
}
