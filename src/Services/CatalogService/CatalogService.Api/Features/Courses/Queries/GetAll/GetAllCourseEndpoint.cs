using CatalogService.Api.Features.Courses.Commands.Create;
using CatalogService.Api.Features.Courses.Dtos;
using Shared.Filters;

namespace CatalogService.Api.Features.Courses.Queries.GetAll
{
    public static class GetAllCourseEndpoint
    {
        public static RouteGroupBuilder GetAllCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/getallcourse", async (IMediator mediator)
                => (await mediator.Send(new GetAllCourseQuery())).ToGenericResult()).MapToApiVersion(1, 0);

            return group;
        }
    }
}
